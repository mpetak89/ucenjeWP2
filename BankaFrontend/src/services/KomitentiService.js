// import {App} from "../constants"
// import { httpService } from "./httpService";

// async function getKomitenti (){
//     return await httpService.get('/Komitent')
//     .then((res)=>{
//         if(App.DEV) console.table(res.data);
//         return res;
//     }).catch((e)=>{
//         console.log(e);
//     });
// }

// async function obrisiKomitent (sifra_komitenta){
//     return await httpService.delete('/Komitent/'+ sifra_komitenta)
//     .then((res)=>{
//         return {ok: true, poruka: res};
//     }).catch((e)=>{
//         console.log(e);
//     });
// }
  
// async function dodajKomitent (komitent){
// const odgovor = await httpService.post ('/Komitent', komitent)
// .then (()=>{
//     return{ok:true, poruka: 'Dodan komitent'}  
// })
// .catch((e)=>{
//     return {ok: false,  poruka: 'Greška, komitent nije dodan'}
    
// });
// return odgovor;
// }

// async function promijeniKomitent (sifra_komitenta, komitent){
//     const odgovor = await httpService.put ('/Komitent/'+sifra_komitenta, komitent)
//     .then (()=>{
//         return{ok:true, poruka: 'Promjenjen komitent'}  
//     })
//     .catch((e)=>{
//         console.log(e.response.data.errors);
//         return {ok: false,  poruka: 'Greška, komitent nije dodan'}
//     }); 
//    return odgovor;
// }  

// async function getBySifra (sifra_komitenta){
//     return await httpService.get('/Komitent/'+sifra_komitenta)
//     .then((res)=>{
//         if(App.DEV) console.table(res.data);
//         return res.data;
//     }).catch((e)=>{
//         console.log(e)
//         return {poruka: e};
//     });
// }

// export default{
//     getKomitenti,
//     obrisiKomitent,
//     dodajKomitent,
//     promijeniKomitent,
//     getBySifra
// };