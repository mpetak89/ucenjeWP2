import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import Kreditiservice from "../../services/KreditiService";

export default function KreditiDodaj (){
    const navigate = useNavigate(); 

    async function dodajKredit(kredit){
        const odgovor = await Kreditiservice.dodajKredit(kredit); 
        if(odgovor.ok){
          navigate(RoutesNames.KREDITI_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit (e){
        e.preventDefault();
        const podaci = new FormData (e.target);

        const kredit =
        {
            vrsta_Kredita: podaci.get ('naziv'),
            vrsta_Kamate: podaci.get ('kamata'),
            valuta_kredita: podaci.get ("valuta"),
            osiguranje_kredita: podaci.get('osgiruranje')=='on'? true:false
        };

        dodajKredit(kredit);
            
             
    }
    return(
        <Container>

<Form onSubmit = {handleSubmit}>

<Form.Group controlId ="sifra">
        <Form.Label>Šifra kredita</Form.Label>
        <Form.Control 
type="number"
name="sifra" 
/>
    </Form.Group>

    <Form.Group controlId ="naziv">
        <Form.Label>Vrsta kredita</Form.Label>
        <Form.Control 
type="text"
name="naziv" 
/>
    </Form.Group>

    <Form.Group controlId ="kamata">
        <Form.Label>Vrsta kamate</Form.Label>
        <Form.Control 
type="text"
name="kamata" 
/>
    </Form.Group>

    <Form.Group controlId ="valuta">
        <Form.Label>Valuta kredita</Form.Label>
        <Form.Control 
type="text"
name="valuta" 
/>
    </Form.Group>

    <Form.Group controlId ="osiguranje">
        <Form.Check 
        label="Osiguranje kredita"
inline
name="Osiguran" 
/>
    </Form.Group>

    <Row className="akcije">
                    <Col>
                        <Link 
                        className="btn btn-danger"
                        to={RoutesNames.KREDITI_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            Dodaj kredit
                        </Button>
                    </Col>
                </Row>
         </Form>
        </Container>
    );
}