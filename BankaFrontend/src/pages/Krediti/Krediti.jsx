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

async function obrisiKredit (sifra_Kredit){
    const odgovor = await Kreditiservice.obrisiKredit(sifra_Kredit);
    if (odgovor.ok) {
console.log (odgovor.poruka);
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
            <tr>
                <th>vrsta_Kredita</th>
                <th>sifra_Kredit</th>
                <th>Akcija</th>
            </tr>
        </thead>
        <tbody>
                    {Krediti && Krediti.map((kredit, index)=>(
                        <tr key = {index}>
                            <td>{kredit.vrsta_Kredita}</td>
                            <td>{kredit.sifra_Kredita}</td>
                            <td className="centar">
                                <Link to={RoutesNames.KREDITI_NOVI} className="btn btn-success gumb">
                                <IoIosAdd
                                size={25}
                                /> Dodaj
                                </Link>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisiKredit (kredit.sifra_Kredit)}
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