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
    
export default{
    getKrediti,
    obrisiKredit,
};