import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Krediti from "./pages/Krediti/Krediti"
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import KreditiDodaj from "./pages/Krediti/KreditiDodaj"
import KreditiPromijeni from "./pages/Krediti/KreditiPromijeni"

function App() {
return(
  <>
  <NavBar/>
  <Routes>
    <>
    <Route path = {RoutesNames.HOME} element = {<Pocetna/>}/>
    <Route path = {RoutesNames.KREDITI_PREGLED} element = {<Krediti/>}/>
    <Route path = {RoutesNames.KREDITI_NOVI} element = {<KreditiDodaj/>}/>
    <Route path = {RoutesNames.KREDITI_PROMIJENI} element = {<KreditiPromijeni/>}/>
    </>
  </Routes> 
  </>
)
}
export default App
