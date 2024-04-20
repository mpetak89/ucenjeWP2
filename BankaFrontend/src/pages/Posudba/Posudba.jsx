import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import PosudbaService from "../../services/PosudbaService";
import {GrValidate} from "react-icons/gr";
import {IoIosAdd} from "react-icons/io";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { MdDelete } from "react-icons/md";
import { FaEdit } from "react-icons/fa";

export default function Posudba (){
const [posudba, setPosudba] = useState();
const navigate = useNavigate();


async function dohvatiPosudbe (){
    await PosudbaService.getPosudbe()
    .then ((res)=>{
        setPosudba(res.data);
    })
    .catch ((e)=>    {
        alert(e);
    });
}
useEffect(()=>{
    dohvatiPosudbe();
},[]);

async function obrisiPosudba (sifra_posudbe){
    const odgovor = await PosudbaService.obrisiPosudba(sifra_posudbe);
    if (odgovor.ok) {
alert (odgovor.poruka.data.poruka);
dohvatiPosudbe();
    }
}

    return(
        <Container>
            <Link to={RoutesNames.POSUDBA_NOVI} className="btn btn-success gumb">
            <IoIosAdd
            size={25}
            /> Dodaj
            </Link>
    <Table striped bordered hover responsive>
        <thead>
            <tr className="centar">
                <th>Šifra posudbe</th>
                <th>Šifra kredita</th>
                <th>Šifra komitenta</th>
                <th>Datum podizanja</th>
                <th>Datum vraćanja</th>
                <th>Iznos</th>
                <th>Kamata</th>
                <th>Akcija</th>
            </tr>
        </thead>
        <tbody>
                    {posudba && posudba.map((posudba, index)=>(
                        <tr key = {index}>
                            <td className="centar">{posudba.sifra_posudbe}</td>
                            <td className="centar">{posudba.sifra_kredita}</td>
                            <td className="centar">{posudba.sifra_komitenta}</td>
                            <td className="centar">{posudba.datum_podizanja}</td>
                            <td className="centar">{posudba.datum_vracanja}</td>
                            <td className="centar">{posudba.iznos}</td>
                            <td className="centar">{posudba.kamata}</td>

                            <td className="centar">
                                <Link to={RoutesNames.POSUDBA_NOVI} className="btn btn-success gumb2, centar">
                                <IoIosAdd
                                size={25}
                                /> Dodaj
                                </Link>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant="primary"
                                    onClick={()=>{navigate(`/posudba/${posudba.sifra_posudbe}`)}}>
                                    <FaEdit
                                    size={18}
                                    /> Promijeni
                                    </Button>
                                    &nbsp;&nbsp;&nbsp;
                                    <Button 
                                variant="danger gumb2"
                                onClick={()=>obrisiPosudba (posudba.sifra_posudbe)}
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