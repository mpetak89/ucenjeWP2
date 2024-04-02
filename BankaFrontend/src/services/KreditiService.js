
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

async function obrisiKredit (sifra_kredita){
    return await httpService.delete('/Kredit/'+ sifra_kredita)
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
    return {ok: false,  poruka: 'Greška, kredit nije dodan'}
    
});
return odgovor;
}

async function promijeniKredit (sifra_kredita, kredit){
    const odgovor = await httpService.put ('/Kredit/'+sifra_kredita, kredit)
    .then (()=>{
        return{ok:true, poruka: 'Promjenjen kredit'}  
    })
    .catch((e)=>{
        console.log(e.response.data.errors);
        return {ok: false,  poruka: 'Greška, kredit nije dodan'}
    }); 
   return odgovor;
}  

async function getBySifra (sifra_kredita){
    return await httpService.get('/Kredit/'+sifra_kredita)
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        return res;
    }).catch((e)=>{
        console.log(e)
        return {poruka: e};
    });
}

export default{
    getKrediti,
    obrisiKredit,
    dodajKredit,
    promijeniKredit,
    getBySifra
};
