/* eslint-disable import/no-anonymous-default-export */

import React, { useState } from "react"
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
//import { useUserContext } from './UserContext';

export default function (props) {
  let [authMode, setAuthMode] = useState("signin")

  const changeAuthMode = () => {
    setAuthMode(authMode === "signin" ? "signup" : "signin")
  }

  if (authMode === "signin") {
   // const [authMode, setAuthMode] = useState("signin");
    const [emailValue, setEmailValue] = useState('');
   // const [fullNameValue, setFullNameValue] = useState('');
    const [passwordValue, setPasswordValue] = useState('');
    //const [data, setData] = useState('');

    //const { userData, setUserData } = useUserContext();

    const loginUrl = `http://localhost:5282/user/login?emailId=${emailValue}&password=${passwordValue}`;

    const navigate = useNavigate();


    const handleSubmit = async (e) => {
      e.preventDefault();

      try {
        const response = await axios.get(loginUrl);
        if (response.status == 200) {
          navigate('/user');
        }
        else {
          // Handle other status codes if neede
          console.error('Login failed:', response.status);
        }

        //console.log("USER DATA: " + userData);
        console.log(response.data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };




    // useEffect(() => {
    //   console.log("USER DATA: ", userData);
    // }, [userData]);

    return (
      <div className="Auth-body">
        <div className="Auth-form-container">
          <form className="Auth-form" onSubmit={handleSubmit}>
            <div className="Auth-form-content">
              <h3 className="Auth-form-title">Sign In</h3>
              <div className="text-center">
                Not registered yet?{" "}
                <span className="link-primary" onClick={changeAuthMode}>
                  Sign Up
                </span>
              </div>
              <div className="form-group mt-3">
                <label>Email address</label>
                <input
                  type="email"
                  value={emailValue} // Step 2: Set the value to the state variable
                  onChange={(e) => setEmailValue(e.target.value)}
                  className="form-control mt-1"
                  placeholder="Enter email"
                />
              </div>
              <div className="form-group mt-3">
                <label>Password</label>
                <input
                  type="password"
                  value={passwordValue} // Step 2: Set the value to the state variable
                  onChange={(e) => setPasswordValue(e.target.value)}
                  className="form-control mt-1"
                  placeholder="Enter password"
                />
              </div>
              <div className="d-grid gap-2 mt-3">
                <button type="submit" className="btn btn-primary">
                  Submit
                </button>
              </div>
              <p className="text-center mt-2">
                Forgot <a href="#">password?</a>
              </p>
            </div>
          </form>
        </div>
      </div>
    )
  }

  const navigate1 = useNavigate();
  const [emailValue1, setEmailValue1] = useState('');
  const [fullNameValue, setFullNameValue] = useState('');
  const [passwordValue1, setPasswordValue1] = useState('');
  const signupURL = `http://localhost:5282/user/register`;

  const signUpBody = {
    emailId: emailValue1,
    username: fullNameValue,
    password: passwordValue1,
    officeLocation: "SBO - Bangalore",
    ccPoints: 0,
    uRole: "Normal User"
  };
  const handleSignUp = async (e) => {
    e.preventDefault();

    try {
      const response1 = await axios.post(signupURL, signUpBody);
      if (response1.status == 200) {
        // setUserData(response.data);
        navigate1('/');
      }
      else {
        // Handle other status codes if neede
        console.error('Sign Up Failed:', response1.status);
      }

      console.log(response1.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  return (
    <div className="Auth-form-container">
      <form className="Auth-form" onSubmit={handleSignUp}>
        <div className="Auth-form-content">
          <h3 className="Auth-form-title">Sign In</h3>
          <div className="text-center">
            Already registered?{" "}
            <span className="link-primary" onClick={changeAuthMode}>
              Sign In
            </span>
          </div>
          <div className="form-group mt-3">
            <label>Full Name</label>
            <input
              type="name"
              value={fullNameValue} // Step 2: Set the value to the state variable
              onChange={(e) => setFullNameValue(e.target.value)}
              className="form-control mt-1"
              placeholder="e.g EcoRush"
            />
          </div>
          <div className="form-group mt-3">
            <label>Email address</label>
            <input
              type="email"
              value={emailValue1} // Step 2: Set the value to the state variable
              onChange={(e) => setEmailValue1(e.target.value)}
              className="form-control mt-1"
              placeholder="Enter email"
            />
          </div>
          <div className="form-group mt-3">
            <label>Password</label>
            <input
              type="password"
              value={passwordValue1} // Step 2: Set the value to the state variable
              onChange={(e) => setPasswordValue1(e.target.value)}
              className="form-control mt-1"
              placeholder="Enter password"
            />
          </div>
          <div className="d-grid gap-2 mt-3">
            <button type="submit" className="btn btn-primary">
              Submit
            </button>
          </div>
          <p className="text-center mt-2">
            Forgot <a href="#">password?</a>
          </p>
        </div>
      </form>
    </div>
  )
}