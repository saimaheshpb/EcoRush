
import "bootstrap/dist/css/bootstrap.min.css"
import "./App.css"
import { BrowserRouter, Routes, Route } from "react-router-dom"
import Auth from "./Auth"
import Home from "./components/pages/home.js"
import Navbar from "./components/pages/navbar.js"
import './index.css';
import Footer from "./components/pages/footer.js"
import Leaderboard from "./leaderboard/leaderboard.js"
import Activitypage from "./components/pages/activityPage.js"
import Addactivity from "./components/pages/Addactivity"
import { useNavigate } from "react-router-dom"


function App() {
  const Navigate = useNavigate();
  return (
    <>

      <Navbar />


      <Routes>
        <Route path="/" element={< Home />} />
        <Route path="/leaderboard" element={<Leaderboard />} />
        <Route path="/addactivity" element={<Addactivity />} />
        <Route path="/activity" element={<Activitypage />} />
      </Routes>

    </>

  )
}

export default App