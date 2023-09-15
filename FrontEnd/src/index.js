import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import Home from './components/pages/home.js'
import Auth from './Auth';
import { BrowserRouter, Router, Routes, Route, useNavigate } from 'react-router-dom';
import Admin from './components/Admin/admin';
import { UserProvider } from './UserContext';



const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <>
    <BrowserRouter>
      <UserProvider>
        <Routes>
          <Route path="/" element={<Auth />} />
          <Route path="/user*" element={< App />} />
          <Route path="/admin*" element={<Admin />} />
        </Routes>
      </UserProvider>
    </BrowserRouter>
    {/* <App/> */}
  </>


);


