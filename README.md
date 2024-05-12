# Patient Management System

## Overview

The Patient Management System is a web application designed to help clinics and medical facilities manage their patient data and appointments more efficiently. It provides features for viewing, searching, and managing patient information, as well as scheduling appointments.

## Features

- **View Patients**: Users can see a list of patients with their names, next appointment dates, and appointment types.
- **Search Patients**: Search for patients by name or ID.
- **Load More**: Load additional patients when reaching the end of the list.
- **View Patient Details**: Click on a patient to view more details, such as past appointments and medical history.

## Technologies Used

### Frontend

- **React.js**: Used for building the user interface and managing state.
- **Axios**: A promise-based HTTP client for making API requests to the backend.
- **Bootstrap**: Provides pre-designed UI components and styles for a responsive and visually appealing interface.

### Backend

- **Node.js**: A JavaScript runtime environment used to run the server-side logic.
- **Express.js**: A web application framework for Node.js used to build the RESTful API.
- **MongoDB**: A NoSQL database used to store patient and appointment data.
- **Mongoose**: An object data modeling (ODM) library for MongoDB and Node.js, used to define data models and interact with the database.

## Getting Started

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/patient-management-system.git
    cd patient-management-system
    ```

2. Install dependencies:

    ```bash
    # Backend dependencies
    cd backend
    npm install

    # Frontend dependencies
    cd ../frontend
    npm install
    ```

3. Set up environment variables:
   
    - Create a `.env` file in both the `backend` and `frontend` directories and define the necessary environment variables as described in the previous section.

4. Run the application:

    ```bash
    # Start the backend server
    cd backend
    npm start

    # Start the frontend development server
    cd ../frontend
    npm start
    ```

5. Open your web browser and go to [http://localhost:3000](http://localhost:3000) to access the Patient Management System.

## Explanation

The Patient Management System is designed to provide medical facilities with a user-friendly interface for managing patient information and appointments. The frontend is built with React.js, a popular JavaScript library for building user interfaces. It allows for dynamic rendering of patient data and seamless interaction with the backend API.

The backend, built with Node.js and Express.js, serves as the API layer to handle requests from the frontend. It interacts with a MongoDB database to store and retrieve patient data, leveraging the Mongoose library for simplified database operations.

The use of MongoDB provides flexibility in managing unstructured patient data, while Mongoose helps maintain consistency and structure in the database schema.

Overall, the Patient Management System offers an intuitive and efficient solution for clinics and medical facilities to manage their patient records and appointments effectively.


