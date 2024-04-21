import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../constants';

import './NavBar.css';

function NavBar() {
  const navigate = useNavigate();
 
  return (
    <Navbar expand="lg" className="bg-body-tertiary">
      <Container>
        <Navbar.Brand 
           className='linkPocetna'
            onClick={()=>navigate(RoutesNames.HOME)}
        >
             Banka APP
             </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            
          <NavDropdown title="Poslovanje" id="basic-nav-dropdown">
              <NavDropdown.Item 
                onClick={()=>navigate(RoutesNames.KREDITI_PREGLED)}              
                >
                Krediti
                </NavDropdown.Item>
              <NavDropdown.Item
              onClick={()=>navigate(RoutesNames.KOMITENTI_PREGLED)}              
                >
                Komitenti
              </NavDropdown.Item>
              <NavDropdown.Item 
                onClick={()=>navigate(RoutesNames.POSUDBA_PREGLED)}              
                >
                Posudbe
                </NavDropdown.Item>
              <NavDropdown.Divider />
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
        
        <Nav.Link target="_blank" href="https://mpetak1811-001-site1.ftempurl.com/swagger/index.html">API dokumentacija</Nav.Link>
       </Container>
    </Navbar>
  );
}

export default NavBar;
