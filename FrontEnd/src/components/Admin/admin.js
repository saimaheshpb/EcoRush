import React, { useEffect, useState } from "react";
import axios from "axios";
import './Admin.css'

const AfforestationURL = "http://localhost:5282/afforestation/getAFByStatus?status=pending";
const AfforestationApproveURL = "http://localhost:5282/afforestation/updateAfforestation";

const Admin = () => {
  const [afforestation, setAfforestation] = useState([]);

  useEffect(() => {
    axios.get(AfforestationURL)
      .then(res => {
        setAfforestation(res.data);
      })
      .catch(err => console.error(err));
  }, []);

  if (!afforestation.length) {
    return <p>Loading...</p>;
  }

  return (
    <div className="admin-container">
      <h1 className="admin-title">Admin Page</h1>
      <div className="admin-grid">
        {afforestation.map((activity, index) => (
          <div className="admin-card" key={index}>
            <h3 className="activity-title">Afforestation</h3>
            <ul className="activity-details">
              <li>Activity ID: {activity.activityId}</li>
              <li>Date: {activity.activityDate}</li>
              <li>Credits Awarded: {activity.ccawarded}</li>
            </ul>
            <div className="activity-buttons">
              <button className="activity-button approve">Approve</button>
              <button className="activity-button deny">Deny</button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Admin;
