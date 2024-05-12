import React, { useState, useEffect } from 'react';
import axios from 'axios';

const PatientList = () => {
    const [fetchedPatients, setFetchedPatients] = useState([]);
    const [displayedPatients, setDisplayedPatients] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [skip, setSkip] = useState(0);

    const serverURL =  'https://localhost:44363';

    useEffect(() => {
        fetchPatients();
    }, [searchTerm, skip]);

    useEffect(() => {
        setDisplayedPatients(fetchedPatients);
    }, [fetchedPatients]);

    const fetchPatients = async () => {
      try {
          const response = await axios.get(`${serverURL}/api/patients?searchTerm=${searchTerm}&skip=${skip}`);
          const newPatients = response.data;
  
          if (skip > 0) {
              setFetchedPatients(prevPatients => [...prevPatients, ...newPatients]);
          } else {
              setFetchedPatients(newPatients);
          }
      } catch (error) {
          console.error('Error fetching patients:', error);
      }
  };

    const handleSearchChange = (e) => {
        setSearchTerm(e.target.value);
    };

    const handleSearchSubmit = async (e) => {
        e.preventDefault();
        setFetchedPatients([]);
        setSkip(0);
        await fetchPatients();
    };

    const handleLoadMore = () => {
        setSkip(prevSkip => prevSkip + 10);
    };

    return (
        <div  className="container mt-4">
            <form  className="container mt-4" onSubmit={handleSearchSubmit}>
            <div className="input-group">
                <input
                    type="text"
                    value={searchTerm}
                    onChange={handleSearchChange}
                    placeholder="Search by name or ID"
                    list="patients"
                />
                <datalist id="patients">
                    {fetchedPatients.map(patient => (
                        <option key={patient.Id} value={patient.Name} />
                    ))}
                </datalist>
                <div className="input-group-append">
                <button type="submit" className="btn btn-primary">Search</button>
                </div>
                </div>
            </form>
            <table className="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Next / Last  Appointment</th>
                        <th>Appointment Type</th>
                    </tr>
                </thead>
                <tbody>
                    {displayedPatients.map(patient => (
                        <tr key={patient.Id}>
                            <td>{patient.Name}</td>
                            <td>{patient.NextAppointment}</td>
                            <td>{patient.AppointmentType}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            {fetchedPatients.length % 10 === 0 && (
                <button onClick={handleLoadMore} className="btn btn-primary">Load More</button>
            )}
        </div>
    );
};

export default PatientList;


