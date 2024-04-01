// import { useEffect, useState } from "react";
// import { Button, Container, Table } from "react-bootstrap";
// import KreditiService from "../../services/KreditiService";
// import {GrValidate} from "react-icons/gr";
// import {IoIosAdd} from "react-icons/io";
// import { Link, useNavigate } from "react-router-dom";
// import { RoutesNames } from "../../constants";
// import { MdDelete } from "react-icons/md";
// import { FaEdit } from "react-icons/fa";

// export default function Krediti (){
// const [krediti, setKrediti] = useState();
// const navigate = useNavigate();


// async function dohvatiKredite (){
//     await KreditiService.getKrediti()
//     .then ((res)=>{
//         setKrediti(res.data);
//     })
//     .catch ((e)=>    {
//         alert(e);
//     });
// }
// useEffect(()=>{
//     dohvatiKredite();
// },[]);

// async function obrisiKredit (sifra_kredita){
//     const odgovor = await KreditiService.obrisiKredit(sifra_kredita);
//     if (odgovor.ok) {
// alert (odgovor.poruka.data.poruka);
// dohvatiKredite();
//     }
// }
// function osiguranje (kredit){
//     if (kredit.osiguranje_kredita==true) return 'ima';
// return 'nema';
// }


//     return(
//         <Container>
//             <Link to={RoutesNames.KREDITI_NOVI} className="btn btn-success gumb">
//             <IoIosAdd
//             size={25}
//             /> Dodaj
//             </Link>
//     <Table striped bordered hover responsive>
//         <thead>
//             <tr className="centar">
//                 <th>Vrsta Kredita</th>
//                 <th>Šifra Kredita</th>
//                 <th>Valuta Kredita</th>
//                 <th>Vrsta Kamate</th>
//                 <th>Osiguranje Kredita</th>
//                 <th>Akcija</th>
//             </tr>
//         </thead>
//         <tbody>
//                     {krediti && krediti.map((kredit, index)=>(
//                         <tr key = {index}>
//                             <td className="centar">{kredit.vrsta_kredita}</td>
//                             <td className="centar">{kredit.sifra_kredita}</td>
//                             <td className="centar">{kredit.valuta_kredita}</td>
//                             <td className="centar">{kredit.vrsta_kamate}</td>
//                             <td className="centar">{osiguranje(kredit)}</td>

//                             <td className="centar">
//                                 <Link to={RoutesNames.KREDITI_NOVI} className="btn btn-success gumb2, centar">
//                                 <IoIosAdd
//                                 size={25}
//                                 /> Dodaj
//                                 </Link>
//                                 &nbsp;&nbsp;&nbsp;
//                                 <Button
//                                     variant="primary"
//                                     onClick={()=>{navigate(`/krediti/${kredit.sifra_kredita}`)}}>
//                                     <FaEdit
//                                     size={18}
//                                     /> Promijeni
//                                     </Button>
//                                     &nbsp;&nbsp;&nbsp;
//                                     <Button 
//                                 variant="danger gumb2"
//                                 onClick={()=>obrisiKredit (kredit.sifra_kredita)}
//                                 >
//                                     <MdDelete  
//                                     size={25} 
//                                     />Obriši
//                                     </Button>
                                                        
//                                  </td>
//                                                     </tr>
//                              ))}
//                                       </tbody>

//     </Table>
//                 </Container>

//     );
// }