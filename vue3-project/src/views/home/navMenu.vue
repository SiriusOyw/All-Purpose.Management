<template>
   <el-aside width="200px" class="aside"> 
        <el-menu
            default-active="2"
            class="el-menu-vertical-demo" router
        >
            <NavItem v-for="v in items" :key="v.url" :item="v"/>

        </el-menu>
    </el-aside>
</template>

<script setup>
import {ref,reactive} from 'vue'
import {
  Document,
  Menu as IconMenu,
  Location,
  Setting,
} from '@element-plus/icons-vue'
import NavItem from './navItem.vue'

const title = ref('首页');
const items = reactive([
    {title:'首页',url:'/index',icon:Document},
    {
        title:'用户管理',
        url:'/user',
        icon:Location,
        child:[
            {title:'用户详情',url:'/user/info',icon:Document},
            {title:'用户分析',url:'/user/analyse',icon:IconMenu},
        ]
    },
    {
        title:'设备监控',
        url:'/device',
        icon:Document,
        child:[
            {title:'设备列表',url:'/device/list',icon:Document},
            {title:'设备管理',url:'/device/manage',icon:IconMenu},
            {title:'设备维修',url:'/device/repair',icon:Document}
        ]
    },
    {title:'统计分析',url:'/census',icon:Setting}
])

</script>