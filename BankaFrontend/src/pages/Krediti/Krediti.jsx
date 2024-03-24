import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import Kreditiservice from "../../services/KreditiService";
import {GrValidate} from "react-icons/gr";
import {IoIosAdd} from "react-icons/io";
import { Link, Routes } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { MdDelete } from "react-icons/md";


export default function Krediti (){
const [Krediti, setKrediti] = useState();

async function dohvatiKredite (){
    await Kreditiservice.getKrediti()
    .then ((res)=>{
        setKrediti(res.data);
    })
    .catch ((e)=>{alert(e);
    });
}
useEffect(()=>{dohvatiKredite();
},[]);

async function obrisiKredit (sifra_Kredita){
    const odgovor = await Kreditiservice.obrisiKredit(sifra_Kredita);
    if (odgovor.ok) {
alert (odgovor.poruka.data.poruka);
dohvatiKredite();
    }
}

    return(
        <Container>
            <Link to={RoutesNames.KREDITI_NOVI} className="btn btn-success gumb">
            <IoIosAdd
            size={25}
            /> Dodaj
            </Link>
    <Table striped bordered hover responsive>
        <thead>
            <tr className="centar">
                <th>Vrsta Kredita</th>
                <th>Šifra Kredita</th>
                <th>Akcija</th>
            </tr>
        </thead>
        <tbody>
                    {Krediti && Krediti.map((kredit, index)=>(
                        <tr key = {index}>
                            <td td className="centar">{kredit.vrsta_Kredita}</td>
                            <td className="centar">{kredit.sifra_Kredita}</td>
                            <td className="centar">
                                <Link to={RoutesNames.KREDITI_NOVI} className="btn btn-success gumb2">
                                <IoIosAdd
                                size={25}
                                /> Dodaj
                                </Link>
                                &nbsp;&nbsp;&nbsp;
                                <Button 
                                variant="danger gumb2"
                                onClick={()=>obrisiKredit (kredit.sifra_Kredita)}
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