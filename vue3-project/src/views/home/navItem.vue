<template>

         <!-- 无子级 -->
         <el-menu-item :index="basePath" v-if="!item.child">
          <el-icon><component :is="item.flag"></component></el-icon>
          <span>{{item.name}}</span>
        </el-menu-item>
        <!-- 有子级 -->
        <el-sub-menu :index="basePath" v-else>
            <template #title>
               <el-icon><component :is="item.flag"></component></el-icon>
               <span>{{item.name}}</span>
            </template>
            <NavItem  v-for="sub in item.child" :key="sub.url" :item="sub" :basePath="sub.url" />
         </el-sub-menu>

</template>

<script setup>
import {ref,reactive} from 'vue'


const {item,basePath} = defineProps({
   item:{
        type:Object,
    },
    basePath:{
       type:String
    }
})




</script>