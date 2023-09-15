import React from 'react';
import axios from 'axios';
import { useEffect } from 'react';
import { useState } from 'react';

// import Imagee from "../../assets/service1.png";
// import Imageee from "../../assets/service2.png";
// import Imageeee from "../../assets/service3.png";
const Activitypage = () => {

  const afforestationURL = 'http://localhost:5282/afforestation/getAFByEmail?email=saimahehpb@gmail.com';
  const carpoolingURL = 'http://localhost:5282/carpooling/getByEmail?email=saimahehpb@gmail.com';
  const evTravelURL = 'http://localhost:5282/evTravel/getByEmail?email=saimahehpb@gmail.com';
  const walkCycleURL = 'http://localhost:5282/walk-cycle/getByEmail?email=saimahehpb@gmail.com';

  // const afforestationCall = async (e) => {
  //   try {
  //     const response = await axios.get(afforestationURL);
  //     if (response.status == 200) {
  //       console.log(response.data);
  //     }
  //     else {
  //       // Handle other status codes if neede
  //       console.error('API failed:', response.status);
  //     }
  //   } catch (error) {
  //     console.error('Error fetching data:', error);
  //   }
  // };
  const [afforestationData, setAfforestationData] = useState([]);
  const [evData, setEVData] = useState([]);
  const [cycleData, setCycleData] = useState([]);


  useEffect(() => {
    // Fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await axios.get(afforestationURL);
        if (response.status === 200) {
          setAfforestationData(response.data);
        } else {
          // Handle other status codes if needed
          console.error('API failed:', response.status);
        }
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData(); // Call the fetchData function
  }, [afforestationURL]); // Execute when afforestationURL changes

  useEffect(() => {
    // Fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await axios.get(evTravelURL);
        if (response.status === 200) {
          setEVData(response.data);
        } else {
          // Handle other status codes if needed
          console.error('API failed:', response.status);
        }
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData(); // Call the fetchData function
  }, [evTravelURL]); // Execute when afforestationURL changes


  useEffect(() => {
    // Fetch data when the component mounts
    const fetchData = async () => {
      try {
        const response = await axios.get(walkCycleURL);
        if (response.status === 200) {
          setCycleData(response.data);
        } else {
          // Handle other status codes if needed
          console.error('API failed:', response.status);
        }
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData(); // Call the fetchData function
  }, [walkCycleURL]); // Execute when afforestationURL changes

  // afforestationCall();

  return (
    <div id="service" className="w-full min-h-screen p-2 flex items-center bg-gradient-to-b from-white to-gray-400">
      <div className="max-w-7xl mx-auto py-12 px-4 sm:px-6 lg:py-16 lg:px-8">
        <h2 className="text-4xl font-bold text-gray-800 mb-6">Your <span className="text-amber-800">Activity</span></h2>
        <p className="text-lg text-gray-700 mb-8">
          See your previous Activity
        </p>

        <div className="container mx-auto px-4">
          <div className="flex flex-wrap -mx-4">
            {afforestationData.map((activity) => (
              <div key={activity.activityId} className="w-full md:w-1/3 px-4 mb-8">
                <div className="bg-white rounded-lg shadow-lg overflow-hidden">
                  <div className="p-4">
                    <h2 className="text-lg font-bold text-gray-800 mb-2">Afforestation</h2>
                    <p className="text-gray-700 leading-relaxed mb-4">
                      Activity Date: {activity.activityDate}<br />
                      CC Awarded: {activity.ccawarded}<br />
                      Status: {activity.status}<br />
                      Plantation Location: {activity.plantaionLoc}<br />
                      {/* Add more fields as needed */}
                    </p>
                  </div>
                </div>
              </div>
            ))}


            {evData.map((activity) => (
              <div key={activity.activityId} className="w-full md:w-1/3 px-4 mb-8">
                <div className="bg-white rounded-lg shadow-lg overflow-hidden">
                  <div className="p-4">
                    <h2 className="text-lg font-bold text-gray-800 mb-2">EV Travel</h2>
                    <p className="text-gray-700 leading-relaxed mb-4">
                      Activity Date: {activity.activityDate}<br />
                      CC Awarded: {activity.ccawarded}<br />
                      Status: {activity.status}<br />
                      Distance Travelled: {activity.distance}<br />
                      {/* Add more fields as needed */}
                    </p>
                  </div>
                </div>
              </div>

            ))}

            {cycleData.map((activity) => (
              <div key={activity.activityId} className="w-full md:w-1/3 px-4 mb-8">
                <div className="bg-white rounded-lg shadow-lg overflow-hidden">
                  <div className="p-4">
                    <h2 className="text-lg font-bold text-gray-800 mb-2">Cycle Data</h2>
                    <p className="text-gray-700 leading-relaxed mb-4">
                      Activity Date: {activity.activityDate}<br />
                      CC Awarded: {activity.ccawarded}<br />
                      Status: {activity.status}<br />
                      Distance Travelled: {activity.distance}<br />
                      {/* Add more fields as needed */}
                    </p>
                  </div>
                </div>
              </div>
            ))}

          </div>
        </div>
      </div>
    </div>

  );
}

export default Activitypage;