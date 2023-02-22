import axios from 'axios'
import { LocalUserHelper } from '../helpers/LocalUserHelper.js'

// Base URL.
axios.defaults.baseURL = "/api/";

// Set interceptor for assigning token.
axios.interceptors.request.use(config => {
    const token = LocalUserHelper.getUser()?.token;    
    config.headers.Authorization = "Bearer " + token;

    return config;
});

//Set interceptor for response error.
axios.interceptors.response.use(response => {
  return response;
}, function (error) {
  return Promise.reject(error.response);
});
