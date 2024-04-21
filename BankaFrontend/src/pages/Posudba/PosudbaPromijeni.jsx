import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import PosudbaService from "../../services/PosudbaService";
import { RoutesNames } from "../../constants";


export default function PosudbaPromijeni (){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [posudba, setPosudba] = useState({});

    async function dohvatiPosudbe(){
        await PosudbaService.getBySifra(routeParams.sifra_posudbe)
       .then((res)=>{
        setKomitent(res.data)
       })
        .catch ((e)=>{
        alert (e.poruka);
    });
}
useEffect(()=>{
    dohvatiPosudbe();
},[]);

async function promijeniPosudbe(posudba){
    const odgovor = await PosudbaService.promijeniPosudba(routeParams.sifra_posudbe,posudba);
    if(odgovor.ok){
      navigate(RoutesNames.POSUDBA_PREGLED);
          }else{
            console.log (odgovor);
    alert(odgovor.poruka);
}
}

function handleSubmit (e){
e.preventDefault();
const podaci = new FormData(e.target);

const posudba = 
{
    sifra_posudbe: parseInt (podaci.get('sifra_posudbe')),
    sifra_kredita: parseInt (podaci.get('sifra_kredita')),
    sifra_komitenta: parseInt (podaci.get('sifra_komitenta')),
    datum_podizanja: podaci.get('datum_podizanja'),
    datum_vracanja: podaci.get ('datum_vracanja'),
    iznos: parseInt (podaci.get ('iznos')),
    kamata: parseInt(podaci.get ('kamata')),
  };

  promijeniPosudba(posudba);
}

    return(
        <Container>

<Form onSubmit = {handleSubmit}>

<Form.Group controlId ="sifra_posudbe">
        <Form.Label>Šifra posudbe</Form.Label>
        <Form.Control 
type="number"
name="sifra" 
/>
    </Form.Group>

    <Form.Group controlId ="sifra_kredita">
        <Form.Label>Šifra kredita</Form.Label>
        <Form.Control 
type="number"
name="sifra" 
/>
    </Form.Group>

    <Form.Group controlId ="sifra_komitenta">
        <Form.Label>Šifra komitenta</Form.Label>
        <Form.Control 
type="number"
name="sifra" 
/>
    </Form.Group>
    <Form.Group controlId ="datum_podizanja">
        <Form.Label>Datum podizanja</Form.Label>
        <Form.Control 
type="date"
name="datum podizanja" 
/>
    </Form.Group>

    <Form.Group controlId ="datum_vracanja">
        <Form.Label>Datum vracanja</Form.Label>
        <Form.Control 
type="date"
name="datum vracanja" 
/>
    </Form.Group>

    <Form.Group controlId ="iznos">
        <Form.Label>Iznos</Form.Label>   
        <Form.Control 
type="number"
name="iznos" 
/>
    </Form.Group>

    <Form.Group controlId ="kamata">
        <Form.Label>Kamata</Form.Label>
        <Form.Control 
type="decimal"
name="kamata" 
/>
    </Form.Group>

            <Row className="akcije">
                            <Col>
                                <Link 
                                className="btn btn-danger"
                                to={RoutesNames.POSUDBA_PROMIJENI}>Odustani</Link>
                            </Col>
                            <Col>
                                <Button
                                    variant="primary"
                                    type="submit"
                                >
                                    Promijeni posudbu
                                </Button>
                            </Col>
                        </Row>
                 </Form>
                </Container>
            );
        }