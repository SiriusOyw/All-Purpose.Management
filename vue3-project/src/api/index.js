import axios from 'axios'

const service = axios.create({
    baseURL:'http://47.109.25.112:10089/api/'
})

//请求拦截器 发送请求时的处理
service.interceptors.request.use(config=>config);

//响应拦截器 接收到数据处理
service.interceptors.response.use(res=>{
    //错误 码判断
    return res
},err=>{
    return Promise.reject(err)
});

export default service