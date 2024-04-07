import {App} from "../constants"
import { httpService } from "./httpService";

async function getPosudbe (){
    return await httpService.get('/Posudba')
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        return res;
    }).catch((e)=>{
        console.log(e);
    });
}

async function obrisiPosudba (sifra_posudbe){
    return await httpService.delete('/Posudba/'+ sifra_posudbe)
    .then((res)=>{
        return {ok: true, poruka: res};
    }).catch((e)=>{
        console.log(e);
    });
}
  
async function dodajPosudba (posudba){
const odgovor = await httpService.post ('/Posudba', posudba)
.then (()=>{
    return{ok:true, poruka: 'Dodana posudba'}  
})
.catch((e)=>{
    return {ok: false,  poruka: 'Greška, posudba nije dodana'}
    
});
return odgovor;
}

async function promijeniPosudba (sifra_posudbe, posudba){
    const odgovor = await httpService.put ('/Posudba/'+sifra_posudbe, posudba)
    .then (()=>{
        return{ok:true, poruka: 'Promjenjena posudba'}  
    })
    .catch((e)=>{
        console.log(e.response.data.errors);
        return {ok: false,  poruka: 'Greška, posudba nije dodana'}
    }); 
   return odgovor;
}  

async function getBySifra (sifra_posudbe){
    return await httpService.get('/Posudba/'+sifra_posudbe)
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        return res.data;
    }).catch((e)=>{
        console.log(e)
        return {poruka: e};
    });
}

export default{
    getPosudbe,
    obrisiPosudba,
    dodajPosudba,
    promijeniPosudba,
    getBySifra
};