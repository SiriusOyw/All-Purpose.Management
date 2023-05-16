import {createRouter,createWebHashHistory} from 'vue-router'

const routes = [
    {
        path:'/',
        redirect:'/home'  //重定向
    },
    // {
    //     path:'/login',
    //     name:'login',
    //     component:()=>import('')
    // },
    {
        path:'/home',  //路径
        name:'home',  //名字 唯一
        meta:{title:'首页'},  //布局页
        redirect:'/index',  //重定向
        component:()=>import('../views/home/index.vue'),
        children:[
            {
                path:'/index',  //首页
                name:'index',
                meta:{title:'首页'},
                component:()=>import('../views/home/index/index.vue')
            },
            {
                path:'/user',  //用户管理
                name:'user',
                meta:{title:'用户管理'},
                component:()=>import('../views/home/user/index.vue'),
                children:[
                    {
                        path:'/user/info',  //用户详情
                        name:'info',
                        meta:{title:'用户详情'},
                        component:()=>import('../views/home/user/info/index.vue')
                    },
                    {
                        path:'analyse',  //用户分析
                        name:'analyse',
                        meta:{title:'用户分析'},
                        component:()=>import('../views/home/user/analyse/index.vue')
                    },
                ]
            },
            {
                path:'/device',  //设备监控
                name:'device',
                meta:{title:'设备监控'},
                component:()=>import('../views/home/device/index.vue'),
                children:[
                    {
                        path:'/device/list',  //设备列表
                        name:'list',
                        meta:{title:'设备列表'},
                        component:()=>import('../views/home/device/list/index.vue')
                    },
                    {
                        path:'manage',  //设备管理
                        name:'manage',
                        meta:{title:'设备管理'},
                        component:()=>import('../views/home/device/manage/index.vue')
                    },
                ]
            },
            {
                path:'/census',  //统计分析
                name:'census',
                meta:{title:'统计分析'},
                component:()=>import('../views/home/census/index.vue')
            },
        ]
    }
]

const router = createRouter({
    history:createWebHashHistory(),  //hash
    routes
})

export default router