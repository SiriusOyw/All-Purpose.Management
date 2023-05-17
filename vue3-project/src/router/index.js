import { createRouter, createWebHashHistory } from 'vue-router'

const routes = [
 {
   path: '/',
   redirect:'/login'
 },
 {
      path: '/login',
      name: 'login',
      component: () => import('../views/Login/index.vue')
    },
 {
   path: '/home',
   name: 'home',
   redirect:'/index',
   meta:{title:'首页'},
   component: () => import('../views/Home/index.vue'),
    children:[
        {
        path: '/index',
        name: 'index',
        meta:{title:'首页'},
        component: () => import('../views/Home/index/index.vue')
        },
        {
         path: '/user',
         name: 'user',
         meta:{title:'用户管理'},
         component: () => import('../views/Home/user/index.vue'),
         children:[
            {
               path: 'info',  //用户详情
               name: 'info',
               meta:{title:'用户详情'},
               component: () => import('../views/Home/user/info/index.vue')
            },
            {
               path: '/user/analyse',  //用户分析
               name: 'analyse',
               meta:{title:'用户分析'},
               component: () => import('../views/Home/user/analyse/index.vue')
            },
         ]
         },
         {
            path: '/device',
            name: 'device',
            meta:{title:'设备监控'},
            component: () => import('../views/Home/device/index.vue'),
            children:[
               {
                  path: 'list',  //设备列表
                  name: 'list',
                  meta:{title:'设备列表'},
                  component: () => import('../views/Home/device/list/index.vue')
               },
               {
                  path: '/device/manage',  //设备管理
                  name: 'manage',
                  meta:{title:'设备管理'},
                  component: () => import('../views/Home/device/manage/index.vue')
               },
               {
                  path: '/device/repair',  //设备维修
                  name: 'repair',
                  meta:{title:'设备维修'},
                  component: () => import('../views/Home/device/repair/index.vue')
               },
            ]
         },
            {
               path: '/census',
               name: 'census',
               meta:{title:'统计分析'},
               component: () => import('../views/Home/census/index.vue')
            },
    ]
 }
]
const router = createRouter({
 history: createWebHashHistory(),
 routes
})
export default router