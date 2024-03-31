import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import KreditiService from "../../services/KreditiService";

export default function KreditiDodaj (){
    const navigate = useNavigate(); 

    async function dodajKredit(kredit){
        const odgovor = await KreditiService.dodajKredit(kredit);
        if(odgovor.ok){
          navigate(RoutesNames.KREDITI_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);


        const kredit =
        {
            sifra_kredita: parseInt (podaci.get('sifra_kredita')),
            vrsta_kredita: podaci.get ('vrsta_kredita'),
            valuta_kredita: podaci.get ('valuta_kredita'),
            vrsta_kamate: podaci.get ('vrsta_kamate'),
            osiguranje_kredita: podaci.get('osiguranje_kredita')=='on'? true:false
        };

        dodajKredit(kredit);
            
             
    }
    return(
        <Container>

<Form onSubmit = {handleSubmit}>

<Form.Group controlId ="sifra_kredita">
        <Form.Label>Šifra kredita</Form.Label>
        <Form.Control 
type="text"
name="sifra" 
/>
    </Form.Group>

    <Form.Group controlId ="vrsta_kredita">
        <Form.Label>Vrsta kredita</Form.Label>
        <Form.Control 
type="text"
name="naziv" 
/>
    </Form.Group>

    <Form.Group controlId ="vrsta_kamate">
        <Form.Label>Vrsta kamate</Form.Label>   
        <Form.Control 
type="text"
name="kamata" 
/>
    </Form.Group>

    <Form.Group controlId ="valuta_kredita">
        <Form.Label>Valuta kredita</Form.Label>
        <Form.Control 
type="text"
name="valuta" 
/>
    </Form.Group>

    <Form.Group controlId ="osiguranje_kredita">
        <Form.Check 
        label="Osiguranje kredita"
        
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