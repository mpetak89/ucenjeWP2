import {App} from "../constants"
import { httpService } from "./httpService";

async function getKrediti (){
    return await httpService.get('/Kredit')
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        return res;
    }).catch((e)=>{console.log(e);
    });
    }
    

export default{
    getKrediti,

};