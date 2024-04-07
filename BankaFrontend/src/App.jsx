import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Krediti from "./pages/Krediti/Krediti"
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import KreditiDodaj from "./pages/Krediti/KreditiDodaj"
import KreditiPromijeni from "./pages/Krediti/KreditiPromijeni"
import Komitenti from "./pages/Komitenti/Komitenti"
import KomitentiDodaj from "./pages/Komitenti/KomitentiDodaj"
import KomitentiPromijeni from "./pages/Komitenti/KomitentiPromijeni"
import Posudba from "./pages/Posudba/Posudba"
import PosudbaDodaj from "./pages/Posudba/PosudbaDodaj"
import PosudbaPromijeni from "./pages/Posudba/PosudbaPromijeni"

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

    <Route path = {RoutesNames.KOMITENTI_PREGLED} element = {<Komitenti/>}/>
    <Route path = {RoutesNames.KOMITENTI_NOVI} element = {<KomitentiDodaj/>}/>
    <Route path = {RoutesNames.KOMITENTI_PROMIJENI} element = {<KomitentiPromijeni/>}/>

    <Route path = {RoutesNames.POSUDBA_PREGLED} element = {<Posudba/>}/>
    <Route path = {RoutesNames.POSUDBA_NOVI} element = {<PosudbaDodaj/>}/>
    <Route path = {RoutesNames.POSUDBA_PROMIJENI} element = {<PosudbaPromijeni/>}/>
    </>
  </Routes> 
  </>
)
}
export default App
