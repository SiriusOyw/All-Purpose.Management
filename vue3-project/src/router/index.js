import { createRouter, createWebHashHistory } from 'vue-router'
const routes = [
  {
    path:'/',
    redirect:'/home' //重定向
  },
  // {
  //   path: '/login',
  //   name: 'login',
  //   component: () => import(''),
  // },
  {
    path: '/home',
    name: 'home',
    component: () => import('../view/home/index.vue'),
    children: [
      {
        path: '/index',  //首页
        name: 'index',
        component: () => import('../view/home/index/index.vue')
      },{
        path: '/user',  //用户管理
        name: 'user',
        component: () => import('../view/home/user/index.vue')
      },{
        path: '/device',  //设备监控
        name: 'device',
        component: () => import('../view/home/device/index.vue')
      },{
        path: '/census',  //统计分析
        name: 'census',
        component: () => import('../view/home/census/index.vue')
      },
    ]
  }
]

const router = createRouter({
  history: createWebHashHistory(),  //hash
  routes
})
export default router