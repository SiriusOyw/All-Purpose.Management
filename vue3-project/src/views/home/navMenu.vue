<template>
   <el-aside width="200px" class="aside">
      <el-menu
        :default-active="route.path" exact
        class="el-menu-vertical-demo" router
      >
      <NavItem  v-for="v in items" :key="v.url" :item="v" :basePath="v.url" />
      </el-menu>
   </el-aside>
</template>

<script setup>
import {ref,reactive,onMounted} from 'vue'
import { useRouter ,useRoute} from "vue-router";  //导入路由
import NavItem from './navItem.vue'  //子组件
import {
  House,
  Grid,
  Management,
  List,
  UserFilled,
  Checked,
  Ticket,
  Avatar,
  Picture
} from '@element-plus/icons-vue'
import axios from '@/api'

 const router = useRouter();  
 const route = useRoute();  

 const items = reactive([
        {name:'首页',url:'/index',flag:House},
         {
          name:'用户管理',
          url:'/user',
          flag:UserFilled,
          child:[
            {name:'用户详情',url:'/user/info',flag:Avatar},
            {name:'用户分析',url:'/user/analyse',flag:Grid},
          ]
        },
        {
          name:'设备监控',
          url:'/device',
          flag:Checked,
          child:[
            {name:'设备列表',url:'/device/list',flag:List},
            {name:'设备管理',url:'/device/manage',flag:Management},
            {name:'设备维修',url:'/device/repair',flag:Ticket},
          ]
        },
        {name:'统计分析',url:'/census',flag:Picture},
        
 ])


</script>