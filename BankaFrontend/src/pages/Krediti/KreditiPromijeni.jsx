import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import KreditiService from "../../services/KreditiService";
import { RoutesNames } from "../../constants";


export default function KreditiPromijeni (){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [kredit, setKredit] = useState();

    async function dohvatiKredit(){
        await KreditiService.getBySifra(routeParams.sifra_kredita)
       .then((res)=>{
        console.log (res.data)
        setKredit(res.data)
       })
        .catch ((e)=>{
        alert (e.poruka);
    });
}
useEffect(()=>{
    dohvatiKredit();
},[]);

async function promijeniKredit(kredit){
    const odgovor = await KreditiService.promijeniKredit(routeParams.sifra_kredita,kredit);
    if(odgovor.ok){
      navigate(RoutesNames.KREDITI_PREGLED);
          }else{
            console.log (odgovor);
    alert(odgovor.poruka);
}
}

function handleSubmit (e){
e.preventDefault();
const podaci = new FormData(e.target);

const kredit = 
{
    sifra_kredita: parseInt (podaci.get('sifra_kredita')),
    vrsta_kredita: podaci.get ('vrsta_kredita'),
    vrsta_kamate: podaci.get ('vrsta_kamate'),
    valuta_kredita: podaci.get ('valuta_kredita'),
    osiguranje_kredita: podaci.get('osiguranje_kredita')=='on'? true:false
  };

  promijeniKredit(kredit);
}

    return(
        <Container>

        <Form onSubmit = {handleSubmit}>
        
        <Form.Group controlId ="sifra_kredita">
                <Form.Label>Šifra kredita</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={kredit.sifra_kredita}
        name="sifra" 
        />
            </Form.Group>
        
            <Form.Group controlId ="vrsta_kredita">
                <Form.Label>Vrsta kredita</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={kredit.vrsta_kredita}
        name="naziv" 
        />
            </Form.Group>
        
            <Form.Group controlId ="vrsta_kamate">
                <Form.Label>Vrsta kamate</Form.Label>   
                <Form.Control 
        type="text"
        defaultValue={kredit.vrsta_kamate}
        name="kamata" 
        />
            </Form.Group>
        
            <Form.Group controlId ="valuta_kredita">
                <Form.Label>Valuta kredita</Form.Label>
                <Form.Control 
        type="text"
        defaultValue={kredit.valuta_kredita}
        name="valuta" 
        />
            </Form.Group>
        
            <Form.Group controlId ="osiguranje_kredita">
                <Form.Check 
                label="Osiguranje kredita"
                defaultChecked={kredit.osiguranje_kredita}
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
                                    Promijeni kredit
                                </Button>
                            </Col>
                        </Row>
                 </Form>
                </Container>
            );
        }