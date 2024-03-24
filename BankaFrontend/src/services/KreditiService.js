import {App} from "../constants"
import { httpService } from "./httpService";

async function getKrediti (){
    return await httpService.get('/Kredit')
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        return res;
    }).catch((e)=>{
        console.log(e);
    });
}

async function obrisiKredit (sifra_Kredita){
    return await httpService.delete('/Kredit/'+ sifra_Kredita)
    .then((res)=>{
        return {ok: true, poruka: res};
    }).catch((e)=>{
        console.log(e);
    });
}
  
async function dodajKredit (kredit){
const odgovor = await httpService.post ('/Kredit', kredit)
.then (()=>{
    return{ok:true, poruka: 'Dodan kredit'}  
})
.catch((e)=>{
    console.log(e.response.data.errors.Naziv);
    return {ok: false, poruka:e.response.data.errors.Naziv}
});
return odgovor;
}

export default{
    getKrediti,
    obrisiKredit,
    dodajKredit,
};