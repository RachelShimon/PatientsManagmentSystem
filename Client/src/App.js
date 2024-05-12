import React from 'react';
import PatientList from './components/PatientList';

const App = () => {
  return (
    <div className="container mt-4">
      <h1 className="mb-4">Patients List</h1>
      <PatientList />
    </div>
  );
};

export default App;