import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import PosudbaService from "../../services/PosudbaService";
import {GrValidate} from "react-icons/gr";
import {IoIosAdd} from "react-icons/io";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { MdDelete } from "react-icons/md";
import { FaEdit } from "react-icons/fa";
import { NumberFormatBase, NumericFormat } from "react-number-format";
import moment from "moment";

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

function formatirajDatum(datum_podizanja,datum_vracanja){
    let mdp = moment.utc(datum_podizanja, datum_vracanja);
    if(mdp.hour()==0 && mdp.minutes()==0){
        return mdp.format('DD. MM. YYYY.');
    }
    return mdp.format('DD. MM. YYYY. HH:mm');
    
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
                            <td className="centar">
                            <p>
                                {posudba.datum_podizanja==null 
                                ? 'Nije definirano'
                                :   
                                formatirajDatum(posudba.datum_podizanja)
                                }
                                </p>
                                </td>
                                <td className="centar">
                            <p>
                                {posudba.datum_vracanja==null 
                                ? ''
                                :   
                                formatirajDatum(posudba.datum_vracanja)
                                }
                                </p>
                                </td>
                            <td className="centar">
                            <NumericFormat value={posudba.iznos}
                            displayType={'text'}
                            thousandSeparator='.'
                            decimalSeparator=','
                            decimalScale={2}
                            fixedDecimalScale>
                                </NumericFormat></td>
                            <td className="centar">
                                {posudba.kamata}</td>

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