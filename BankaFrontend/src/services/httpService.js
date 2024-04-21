import axios from "axios";

export const httpService = axios.create({
    baseURL: 'https://mpetak1811-001-site1.ftempurl.com/api/v1',
    
    headers:{
        'Content-Type': 'application/json'
    }
});
function kreirajPoruku(svojstvo, poruka){
    return {svojstvo: svojstvo, poruka: poruka};
}