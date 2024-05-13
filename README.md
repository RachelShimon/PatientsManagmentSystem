
# Patient Management System

## Overview

The Patient Management System is a web application designed to assist clinics and medical facilities in managing patient data and appointments efficiently. It provides features for viewing patients, searching for specific patients, and loading more patient records. The backend of the application is built with ASP.NET Web API, while the frontend is developed using React.js.

## Backend

### Technologies Used

- **ASP.NET Web API**: Provides a framework for building RESTful APIs using .NET.
- **C#**: The primary programming language used in ASP.NET development.
- **Entity Framework**: An ORM (Object-Relational Mapping) tool used for database interaction.

### Controllers

The backend contains a single controller:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using PatientManagmentSystem.API.Services;

namespace PatientManagmentSystem.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        private readonly PatientService _patientService;

        public PatientsController()
        {
            _patientService = new PatientService(new DummyRepository());
        }

        [HttpGet]
        public IHttpActionResult GetPatients(string searchTerm = null, int skip = 0, int take = 10)
        {
            var patients = _patientService.GetPatients(searchTerm, skip, take);
            return Ok(patients);
        }
    }
}
```
### Services
The core logic of the application is contained in the PatientService class, which interacts with the repository:

```csharp
Copy code
using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagmentSystem.API.Models;

namespace PatientManagmentSystem.API.Services
{
    public class PatientService
    {
        private readonly IRepository _repository;

        public PatientService(IRepository repository)
        {
            _repository = repository;
        }

        public List<PatientViewModel> GetPatients(string searchTerm = null, int skip = 0, int take = 10)
        {
            // Logic for retrieving patients and their details
        }

        // Other methods for retrieving appointment details
    }
}
```
## Frontend
### Technologies Used
- **React.js:** A JavaScript library for building user interfaces.
- **Axios:** A promise-based HTTP client for making API requests.
- **Bootstrap:** A front-end framework for designing responsive and mobile-first websites.
### Components
The frontend consists of a single component:

```javascript

import React, { useState, useEffect } from 'react';
import axios from 'axios';

const PatientList = () => {
    // Component state
    const [fetchedPatients, setFetchedPatients] = useState([]);
    const [displayedPatients, setDisplayedPatients] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [skip, setSkip] = useState(0);

    // Backend server URL
    const serverURL = 'https://localhost:44363';

    // useEffect hooks for fetching data
    useEffect(() => {
        fetchPatients();
    }, [searchTerm, skip]);

    useEffect(() => {
        setDisplayedPatients(fetchedPatients);
    }, [fetchedPatients]);

    // Function to fetch patient data
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

    // Other functions for handling user interactions

    // Return the JSX
    return (
        <div className="container mt-4">
            {/* Form for searching patients */}
            <form className="container mt-4" onSubmit={handleSearchSubmit}>
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
            {/* Table to display patient data */}
            <table className="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Next / Last Appointment</th>
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
            {/* Button to load more patients */}
            {fetchedPatients.length % 10 === 0 && (
                <button onClick={handleLoadMore} className="btn btn-primary">Load More</button>
            )}
        </div>
    );
};

export default PatientList;
```
## Getting Started
## Prerequisites
Node.js installed on your machine
.NET Framework installed
### Installation
Clone the repository:
```bash
git clone https://github.com/RachelShimon/PatientsManagmentSystem.git
```


# Start the backend server
Open the backend project through Visual Studio or any other IDE.

# Start the frontend development server
Open the client folder through VS code or any other IDE, and do npm i and then npm run build and npm start


## Additional realizations that I haven't had time to realize or I'm in the middle of realizing -
```
https://docs.google.com/document/d/1Jueudh_Btb_UZqAC5qxCI-wrNsILMsb1a28HoUXPlPo/
```




