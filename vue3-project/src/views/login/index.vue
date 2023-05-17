<template>
   <div class="login">
    <div class="login-content">
      <!-- 表单 -->
      <div class="login-form login-item">
         <p class="login-title">朝夕后台管理系统</p>
         
         <el-form :model="temp" :rules="rules" ref="ruleForm" label-width="70px" class="demo-ruleForm">
            <!-- 用户名 -->        
            <el-form-item label="用户名" prop="user">
               <el-input v-model="temp.user"></el-input>
            </el-form-item>

            <el-form-item label="密码" prop="password">
               <el-input type="password" v-model="temp.password"></el-input>
            </el-form-item>

            <el-form-item>
               <el-button  @click="submitForm(ruleForm)">
                  登录</el-button>
            </el-form-item>
         </el-form>
      </div>
    </div>
   </div>
</template>

<script setup>
import {ref,reactive} from 'vue'
import {useRouter} from 'vue-router' //导入路由
import axios from '@/api'

import {
  ChromeFilled,
  Opportunity,
  SwitchFilled,
  TrendCharts
} from '@element-plus/icons-vue'

 const router = useRouter();
 const temp = reactive({
    user:'123456',
    password:'123456'
 })
const rules = reactive({
      user: [
          {
            required: true,
            message: '请输入用户名',
            trigger: 'blur',
          },
          {
            min: 3,
            max: 18,
            message: '长度为3-18位',
            trigger: 'blur',
          },
        ],
      password: [
         {
         required: true,
         message: '请输入密码',
         trigger: 'blur',
         },
         {
         min: 3,
         max: 18,
         message: '长度为3-18位',
         trigger: 'blur',
         },
      ],
})
const ruleForm = ref(null);
function submitForm(formEl){
   formEl.validate(valid => {
      if (valid) {
         console.log('ok');
         //跳转
         router.push("/home")
      } else {
         console.log('error submit!!')
         return false
      }
   })
}

</script>