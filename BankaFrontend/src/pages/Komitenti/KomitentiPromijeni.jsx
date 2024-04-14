import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import KomitentiService from "../../services/KomitentiService";
import { RoutesNames } from "../../constants";


export default function KomitentiPromijeni (){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [komitent, setKomitent] = useState({});

    async function dohvatiKomitent(){
        await KomitentiService.getBySifra(routeParams.sifra_komitenta)
       .then((res)=>{
        setKomitent(res.data)
       })
        .catch ((e)=>{
        alert (e.poruka);
    });
}
useEffect(()=>{
    dohvatiKomitent();
},[]);

async function promijeniKomitent(komitent){
    const odgovor = await KomitentiService.promijeniKomitent(routeParams.sifra_komitenta,komitent);
    if(odgovor.ok){
      navigate(RoutesNames.KOMITENTI_PREGLED);
          }else{
            console.log (odgovor);
    alert(odgovor.poruka);
}
}

function handleSubmit (e){
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
    grad_stanovanja: podaci.get ('grad_stanovanja'),
  };

  promijeniKomitent(komitent);
}


    return(
        <Container>

        <Form onSubmit = {handleSubmit}>
        
        <Form.Group controlId ="sifra_komitenta">
                <Form.Label>Šifra komitenta</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={komitent.sifra_komitenta}
        name="sifra_komitenta" 
        />
            </Form.Group>
        
            <Form.Group controlId ="oib">
                <Form.Label>OIB</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={komitent.oib}
        name="oib" 
        />
            </Form.Group>
        
            <Form.Group controlId ="ime">
                <Form.Label>Ime komitenta</Form.Label>   
                <Form.Control 
        type="text"
        defaultValue={komitent.ime}
        name="ime" 
        />
            </Form.Group>
        
            <Form.Group controlId ="prezime">
                <Form.Label>Prezime komitenta</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={komitent.prezime}
        name="prezime" 
        />
            </Form.Group>
        
            <Form.Group controlId ="datum_rodenja">
                <Form.Label>Datum rođenja</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={komitent.datum_rodenja}
        name="datum_rodenja" 
        />
            </Form.Group>

            <Form.Group controlId ="ulica_stanovanja">
                <Form.Label>Ulica stanovanja</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={komitent.ulica_stanovanja}
        name="ulica_stanovanja" 
        />
            </Form.Group>

            <Form.Group controlId ="grad_stanovanja">
                <Form.Label>Grad stanovanja</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={komitent.grad_stanovanja}
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
                                    Promijeni komitenta
                                </Button>
                            </Col>
                        </Row>
                 </Form>
                </Container>
            );
        }