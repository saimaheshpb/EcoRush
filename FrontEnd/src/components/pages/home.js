import React from "react";
// import Imagee from "../../assets/1.png";
// import Imageee from "../../assets/2.png";
// import Imageeee from "../../assets/3.png";
import {BrowserRouter,Routes, Route, useNavigate} from 'react-router-dom';
import { Link } from 'react-scroll';
import Leaderboard from '../../leaderboard/leaderboard'
//import Addactivity from './Addactivity.js';

const Home = () => {
   
  return (
    <div id="feature" className="w-full min-h-screen p-2 flex items-center bg-gradient-to-b from-white to-gray-400">
      <div className="max-w-7xl mx-auto py-12 px-4 sm:px-6 lg:py-16 lg:px-8">
      <h2 className="text-4xl font-bold text-gray-800 mb-6">Low Carbon?<span className="text-amber-800"> Zero Carbon!</span></h2>
    <p className="text-lg text-gray-700 mb-8">
      </p>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-8">
        <div className='shadow-md shadow-[#040c16] hover:scale-110 duration-500'>
            <div className="bg-white rounded-lg shadow-lg">
              {/* <img src={Imagee} alt="Property" className="w-full max-h-64 object-cover rounded-t-lg h-1/3 md:h-64" /> */}
              <div className="py-6 px-4">
                <h3 className="text-lg font-medium text-gray-900">Add your Carbon Saving Activities</h3>
                {/* <p className="text-sm text-gray-500">3 bd | 2 ba | 1,500 sqft</p> */}
                <p className="text-lg font-bold text-gray-700 mt-4">Such as Carpooling, Afforestation, EV Travels and Cycling</p>
                <p className="text-lg font-bold text-gray-700 mt-4"></p> 
                
                {/* <button className="mt-6 px-4 py-2 bg-amber-800 text-white rounded-md hover:bg-amber-700">
                  Learn More
                </button> */}
              </div>
            </div>
          </div>
          <div className='shadow-md shadow-[#040c16] hover:scale-110 duration-500'>
            <div className="bg-white rounded-lg shadow-lg">
              {/* <img src={Imageee} alt="Property" className="w-full max-h-64 object-cover rounded-t-lg h-1/3 md:h-64" /> */}
              <div className="py-6 px-4">
                <h3 className="text-lg font-medium text-gray-900">Earn Carbon Credits for your activities</h3>
                {/* <p className="text-sm text-gray-500">4 bd | 3 ba | 2,000 sqft</p> */}
                <p className="text-lg font-bold text-gray-700 mt-4">Redeem the CC </p>
                <p className="text-lg font-bold text-gray-700 mt-4">Save the earth</p> 
                {/* <button className="mt-6 px-4 py-2 bg-amber-800 text-white rounded-md hover:bg-amber-700">
                  View Details
                </button> */}
              </div>
            </div>
          </div>
          <div className='shadow-md shadow-[#040c16] hover:scale-110 duration-500'>
            <div className="bg-white rounded-lg shadow-lg">
              {/* <img src={Imageeee} alt="Property" className="w-full max-h-64 object-cover rounded-t-lg h-1/3 md:h-64" /> */}
              <div className="py-6 px-4">
                <h3 className="text-lg font-medium text-gray-900">Compete and win rewards globally</h3>
                {/* <p className="text-sm text-gray-500">2 bd | 1 ba | 1,000 sqft</p> */}
                <p className="text-lg font-bold text-gray-700 mt-4">View the leaderboard, and get inspired</p>
                <p className="text-lg font-bold text-gray-700 mt-4"></p> 
                 <Link to= "/Addactivity">
                {/* <button className="mt-6 px-4 py-2 bg-amber-800 text-white rounded-md hover:bg-amber-700">
                 Add New Activity
                </button> */}
                </Link>
               
                <Routes>
                  {/* <Route path="/leaderboard" element={<Leaderboard />} /> */}
                  {/* <Route path="/addactivity" element={<Addactivity />} />
                  <Route path="/activity" element={<Activitypage />} /> */}
                </Routes>

              </div>
            </div>
          </div>
          
        
        </div>
      </div>
    </div>
    
  );
};

export default Home;