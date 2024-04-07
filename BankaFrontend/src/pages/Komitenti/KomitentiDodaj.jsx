import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import KomitentiService from "../../services/KomitentiService";

export default function KomitentiDodaj (){
    const navigate = useNavigate(); 

    async function dodajKomitent(komitent){
        const odgovor = await KomitentiService.dodajKomitent(komitent);
        if(odgovor.ok){
          navigate(RoutesNames.KOMITENTI_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);


        const komitent =
        {
            sifra_komitenta: parseInt (podaci.get('sifra_komitenta')),
            oib: parseInt (podaci.get('oib')),
            ime: podaci.get ('ime'),
            prezime: podaci.get ('prezime'),
            datum_rodenja: podaci.get ('datum_rodenja'),
            ulica_stanovanja: podaci.get ('ulica_stanovanja'),
            grad_stanovanja: podaci.get ('grad_stanovanja')
        };

        dodajKomitent(komitent);
    }
    return(
        <Container>

<Form onSubmit = {handleSubmit}>

<Form.Group controlId ="sifra_komitenta">
        <Form.Label>Šifra komitenta</Form.Label>
        <Form.Control 
type="number"
name="sifra_komitenta" 
/>
    </Form.Group>

    <Form.Group controlId ="oib">
        <Form.Label>OIB</Form.Label>
        <Form.Control 
type="number"
name="oib" 
/>
    </Form.Group>

    <Form.Group controlId ="ime">
        <Form.Label>Ime</Form.Label>   
        <Form.Control 
type="text"
name="ime" 
/>
    </Form.Group>

    <Form.Group controlId ="prezime">
        <Form.Label>Prezime</Form.Label>
        <Form.Control 
type="text"
name="prezime" 
/>
    </Form.Group>

    <Form.Group controlId ="datum_rodenja">
        <Form.Label>Datum rođenja</Form.Label>
        <Form.Control 
type="date"
name="datum_rodenja" 
/>
    </Form.Group>

<Form.Group controlId ="ulica_stanovanja">
    <Form.Label>Ulica stanovanja</Form.Label>
    <Form.Control 
type="text"
name="ulica_stanovanja" 
/>
</Form.Group>

<Form.Group controlId ="grad_stanovanja"n>
    <Form.Label>Grad stanovanja</Form.Label>
    <Form.Control 
type="text"
name="grad_stanovanja" 
/>
</Form.Group>

    <Row className="akcije">
                    <Col>
                        <Link 
                        className="btn btn-danger"
                        to={RoutesNames.KOMITENTI_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            Dodaj komitenta
                        </Button>
                    </Col>
                </Row>
         </Form>
        </Container>
    );
}