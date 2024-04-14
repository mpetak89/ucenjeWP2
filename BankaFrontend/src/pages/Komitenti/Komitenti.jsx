import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import KomitentiService from "../../services/KomitentiService";
import {GrValidate} from "react-icons/gr";
import {IoIosAdd} from "react-icons/io";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { MdDelete } from "react-icons/md";
import { FaEdit } from "react-icons/fa";

export default function Komitenti (){
const [komitenti, setKomitenti] = useState();
const navigate = useNavigate();


async function dohvatiKomitente (){
    await KomitentiService.getKomitenti()
    .then ((res)=>{
        setKomitenti(res.data);
    })
    .catch ((e)=>    {
        alert(e);
    });
}
useEffect(()=>{
    dohvatiKomitente();
},[]);

async function obrisiKomitent (sifra_komitenta){
    const odgovor = await KomitentiService.obrisiKomitent(sifra_komitenta);
    if (odgovor.ok) {
alert (odgovor.poruka.data.poruka);
dohvatiKomitente();
    }
}

    return(
        <Container>
            <Link to={RoutesNames.KOMITENTI_NOVI} className="btn btn-success gumb">
            <IoIosAdd
            size={25}
            /> Dodaj
            </Link>
    <Table striped bordered hover responsive>
        <thead>
            <tr className="centar">
                <th>Šifra komitenta</th>
                <th>OIB</th>
                <th>Ime komitenta</th>
                <th>Prezime komitenta</th>
                <th>Datum rođenja</th>
                <th>Ulica stanovanja</th>
                <th>Grad</th>
                <th>Akcija</th>
            </tr>
        </thead>
        <tbody>
                    {komitenti && komitenti.map((komitent, index)=>(
                        <tr key = {index}>
                            <td className="centar">{komitent.sifra_komitenta}</td>
                            <td className="centar">{komitent.oib}</td>
                            <td className="centar">{komitent.ime}</td>
                            <td className="centar">{komitent.prezime}</td>
                            <td className="centar">{komitent.datum_rodenja}</td>
                            <td className="centar">{komitent.ulica_stanovanja}</td>
                            <td className="centar">{komitent.grad_stanovanja}</td>

                            <td className="centar">
                                <Link to={RoutesNames.KOMITENTI_NOVI} className="btn btn-success gumb2, centar">
                                <IoIosAdd
                                size={25}
                                /> Dodaj
                                </Link>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant="primary"
                                    onClick={()=>{navigate(`/komitenti/${komitent.sifra_komitenta}`)}}>
                                    <FaEdit
                                    size={18}
                                    /> Promijeni
                                    </Button>
                                    &nbsp;&nbsp;&nbsp;
                                    <Button 
                                variant="danger gumb2"
                                onClick={()=>obrisiKomitent (komitent.sifra_komitenta)}
                                >
                                    <MdDelete  
                                    size={25} 
                                    />Obriši
                                    </Button>
                                                        
                                 </td>
                                                    </tr>
                             ))}
                                      </tbody>

    </Table>
                </Container>

    );
}