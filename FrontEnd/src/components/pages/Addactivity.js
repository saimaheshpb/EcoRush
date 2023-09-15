import React, { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';
import './form.css'

const Addactivity = () => {
  const [formData, setFormData] = useState({
    selectedOption: '',
    EmailId: '',
    ActivityDate: '',
    PlantationLoc: '',
    Evidence: '',
    StartLoc: '',
    EndLoc: '',
    ccawarded: '',
    distance: '',
    image: null,
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleImageChange = (e) => {
    const image = e.target.files[0];
    setFormData({ ...formData, image });
  };

  const handleSelectChange = (e) => {
    const selectedOption = e.target.value;
    setFormData({ ...formData, selectedOption });
  };


  const afforestationURL = 'http://localhost:5282/afforestation/addAfforestation';
  const carpoolingURL = 'http://localhost:5282/carpooling/addCarpool';
  const evTravelURL = 'http://localhost:5282/evTravel/addEvTravel';
  const walkCycleURL = 'http://localhost:5282/walk-cycle/addWalkCycle';

  const [afforestationData, setAfforestationData] = useState([]);

  // Create a function to handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault(); // Prevent the default form submission behavior

    console.log(formData.selectedOption)

    if (formData.selectedOption === 'afforestation') {
      console.log("POKEMON")
      const afforestationBody = {
        activityId: 0, // You may want to change this value
        emailId: formData.EmailId,
        activityDate: formData.ActivityDate,
        ccawarded: 0, // Parse as integer if needed
        status: "PENDING",
        plantaionLoc: formData.PlantationLoc,
        activityType: formData.selectedOption, // Assuming selectedOption corresponds to activityType
        distance: parseFloat(formData.distance), // Parse as float if needed
        // evidence: formData.Evidence,
        evidence: null
      };

      // If you want to remove properties with null or empty values from the object:
      for (const key in afforestationBody) {
        if (afforestationBody[key] === null || afforestationBody[key] === '') {
          delete afforestationBody[key];
        }
      }

      try {
        // Make the POST request to your API
        const response = await axios.post(afforestationURL, afforestationBody);

        if (response.status === 200) {
          // Handle success, update state, show a success message, etc.
          console.log('API response:', response.data);
        } else {
          // Handle other status codes if needed
          console.error('API failed:', response.status);
        }
      } catch (error) {
        // Handle network errors or API request errors
        console.error('Error making API request:', error);
      }
    }

    else if(formData.selectedOption === 'evTravel') {
      console.log("POKEMONcar")
      const evBody = {
        activityId: 0,
        emailId: formData.EmailId,
        activityDate: formData.ActivityDate,
        ccawarded: 0,
        status: "PENDING",
        startLoc: formData.StartLoc,
        endLoc: formData.EndLoc,
        distance: formData.distance,
        evidence: null
      };

      // If you want to remove properties with null or empty values from the object:
      for (const key in evBody) {
        if (evBody[key] === null || evBody[key] === '') {
          delete evBody[key];
        }
      }

      try {
        // Make the POST request to your API
        const response = await axios.post(evTravelURL, evBody);

        if (response.status === 200) {
          // Handle success, update state, show a success message, etc.
          console.log('API response:', response.data);
        } else {
          // Handle other status codes if needed
          console.error('API failed:', response.status);
        }
      } catch (error) {
        // Handle network errors or API request errors
        console.error('Error making API request:', error);
      }
    }

    else if(formData.selectedOption === 'walkCycle') {
      console.log("POKEMONwalk")
      const cycleBody = {
        activityId: 0,
        emailId: formData.EmailId,
        activityDate: formData.ActivityDate,
        ccawarded: 0,
        status: "PENDING",
        activityType: "Cycling",
        distance: formData.distance,
        evidence: null
      };

      // If you want to remove properties with null or empty values from the object:
      for (const key in cycleBody) {
        if (cycleBody[key] === null || cycleBody[key] === '') {
          delete cycleBody[key];
        }
      }

      try {
        // Make the POST request to your API
        const response = await axios.post(walkCycleURL, cycleBody);

        if (response.status === 200) {
          // Handle success, update state, show a success message, etc.
          console.log('API response:', response.data);
        } else {
          // Handle other status codes if needed
          console.error('API failed:', response.status);
        }
      } catch (error) {
        // Handle network errors or API request errors
        console.error('Error making API request:', error);
      }
    }

    // Create an object for the request body

  };


  return (
    <div>
      <h1 className='Margin1'>Add an Activity</h1>
      <label className='Margin'>
        Select activity category: <t />
        <select name="selectedOption" onChange={handleSelectChange} value={formData.selectedOption} className='FormText1'>
          <option value="">Select</option>
          <option value="afforestation">Afforestation</option>
          <option value="carpooling">Carpooling</option>
          <option value="evTravel">EvTravel</option>
          <option value="walkCycle">WalkCycle</option>
        </select>
      </label>


      {formData.selectedOption === 'afforestation' && (
        <div>

          <label className='Margin'>
            Email Id:<t />
            <input
              type="text"
              name="EmailId"
              value={formData.EmailId}
              onChange={handleInputChange}
              className='FormText' />
          </label>
          <br />
          <label className='Margin'>
            Activity Date:<t />
            <input
              type="Date"
              name="ActivityDate"
              value={formData.ActivityDate}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Plantation Location:<t />
            <input
              type="text"
              name="PlantationLoc"
              value={formData.PlantationLoc}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Upload Image:<t />
            <input
              type="file"
              name="image"
              accept="image/*"
              onChange={handleImageChange} className='FormText'
            />
          </label>
        </div>

      )}

      {formData.selectedOption === 'carpooling' && (
        <div>
          <label className='Margin'>
            <br />
            Email Id: <t /> {" "}
            <input
              type="text"
              name="EmailId"
              value={formData.EmailId}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Activity Date:<t />
            <input
              type="Date"
              name="ActivityDate"
              value={formData.ActivityDate}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Start Location:<t />
            <input
              type="text"
              name="StartLoc"
              value={formData.StartLoc}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            End Location:<t />
            <input
              type="text"
              name="EndLoc"
              value={formData.EndLoc}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <br />
          <label className='Margin'>
            Distance Travelled:<t />
            <input
              type="text"
              name="distance"
              value={formData.distance}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Upload Image:<t />
            <input
              type="file"
              name="image"
              accept="image/*"
              onChange={handleImageChange} className='FormText'
            />
          </label>
        </div>
      )}

      {formData.selectedOption === 'evTravel' && (
        <div>
          <br />
          <label className='Margin'>
            Email Id:<t />
            <input
              type="text"
              name="EmailId"
              value={formData.EmailId}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Activity Date:<t />
            <input
              type="Date"
              name="ActivityDate"
              value={formData.ActivityDate}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Start Location:<t />
            <input
              type="text"
              name="StartLoc"
              value={formData.StartLoc}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            End Location:<t />
            <input
              type="text"
              name="EndLoc"
              value={formData.EndLoc}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Distance Travelled:<t />
            <input
              type="text"
              name="distance"
              value={formData.distance}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Upload Image:<t />
            <input
              type="file"
              name="image"
              accept="image/*"
              onChange={handleImageChange} className='FormText'
            />
          </label>
        </div>
      )}

      {formData.selectedOption === 'walkCycle' && (
        <div>
          <br />
          <label className='Margin'>
            Email Id:<t />
            <input
              type="text"
              name="EmailId"
              value={formData.EmailId}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Activity Date:<t />
            <input
              type="Date"
              name="ActivityDate"
              value={formData.ActivityDate}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Distance:<t />
            <input
              type="text"
              name="distance"
              value={formData.distance}
              onChange={handleInputChange} className='FormText'
            />
          </label>
          <br />
          <label className='Margin'>
            Upload Image:<t />
            <input
              type="file"
              name="image"
              accept="image/*"
              onChange={handleImageChange} className='FormText'
            />
          </label>
        </div>
      )
      }
<div>
  <label className='Margin'>
    <br />
    <button 
      type="submit" 
      onClick={handleSubmit}
      style={{
        backgroundColor: 'blue',      // Background color
        color: 'white',               // Text color
        padding: '10px 20px',         // Padding
        border: 'none',              // Remove border
        borderRadius: '5px',          // Rounded corners
        cursor: 'pointer'            // Change cursor to pointer on hover
      }}
    >
      Submit
    </button>
  </label>
</div>


      {/* Display form data */}
      {/* <div>
        <h2 className='Margin'>Form Data:</h2>
        <pre>{JSON.stringify(formData, null, 2)}</pre>
      </div> */}
    </div>
  );
};

export default Addactivity;