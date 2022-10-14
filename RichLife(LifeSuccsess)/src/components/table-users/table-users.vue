<template>
   <div class="table-users-wrap">
      <!-- v-if="innerItems" -->
      <i-new-table class="table-users"  :items="innerItems" 
         :gridTemplateColumns="'40px 1fr 1.5fr 1.5fr 40px 40px 40px'"
         :columnGap="'2px'"
         :rowGap="'2px'">
         <template slot="head">
            <div class="grid-item">
               <div class="item head center">#</div>
            </div>
            <div class="grid-item">
               <div class="item head">Имя</div>
            </div>
            <div class="grid-item">
               <div class="item head">Email</div>
            </div>
            <div class="grid-item">
               <div class="item head">Реферальная ссылка</div>
            </div>
            <div class="grid-item">
               <div class="item head center white" title="Указать, что пользователь оформил программу"><img src="/assets/img/icons/tookTheProgram.svg" alt=""></div>
            </div>
            <div class="grid-item">
               <div class="item head center white" title="Назначить администратором"><img src="/assets/img/icons/isAdmin.svg" alt=""></div>
            </div>
            <div class="grid-item">
               <div class="item head center white" title="Удалить пользователя"><img src="/assets/img/icons/delete.svg" alt=""></div>
            </div>
         </template>

         <template #body="data">
            <div class="grid-item">
               <div class="item center" v-if="data.item.IsAdmin" title="Администратор"><img src="/assets/img/icons/user-admin.svg" alt=""></div>
               <div class="item center" v-if="!data.item.IsAdmin" title="Обычный пользователь"><img src="/assets/img/icons/user-simple.svg" alt=""></div>
            </div>
            <div class="grid-item">
               <div class="item">Elisabeth Doe</div>
            </div>
            <div class="grid-item">
               <div class="item">exampla@gmail.com</div> <!-- {{ data.item.Email }} -->
            </div>
            <div class="grid-item">
               <div class="item">рефферальная ссылка</div>{{ data.item.RefferalLink }}
            </div>
            <div class="grid-item">
               <div class="item center" title="Указать, что пользователь оформил программу">
                  <i-input-checkbox v-model="data.item.TookTheProgram" @input="changeCheckedProgram(data.item)"></i-input-checkbox>
               </div>
            </div>
            <div class="grid-item">
               <div class="item center" title="Назначить администратором">
                  <i-input-checkbox v-model="data.item.IsAdmin" @input="changeCheckedAdmin(data.item)"></i-input-checkbox>
               </div>
            </div>
            <div class="grid-item">
               <div class="item center" title="Удалить пользователя">
                  <i-input-checkbox v-model="data.item.Delete" @input="changeCheckedDelete(data.item)"></i-input-checkbox>
               </div>
            </div>
         </template>
      </i-new-table>

      <div class="nav-wrap">
         <div class="i-button-wrap"><i-button @onClick="openPopupConfirm">Сохранить изменения</i-button></div>
         <i-new-pagination v-if="page" class="table-users-pagination" :count="page.Count" :size="page.Size" ref="pagination" @onChange="onPaginationChanged($event)" />
      </div>

      <i-modal :contentMaxWidth="'700px'" :show="noteConfirm" @close="noteConfirm = false">
         <notification-confirm @clickConfirm="saveChanges" @clickCancel="noteConfirm = false" :image="'/assets/img/icons/surprised.svg'" :hasTitle="false">
            <p class="i-text note-text">Вы действительно хотите сохранить изменения? Если вы также хотите удалить пользователей, <strong class="tt-u">будьте внимательны</strong>! После удаления - восстановление <strong class="tt-u">невозможно</strong></p>
         </notification-confirm>
      </i-modal>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import cookie from "js-cookie"
import PageModel from "../../models/PageModel"
import UserModel from "../../models/UserModel";
import UserRequestModel from "../../models/UserRequestModel"

@Component
export default class TableUsersComponent extends Vue {

   @Prop({ type: Array }) items: Object[]
   @Prop({ type: Object, default: null }) page: PageModel

   /**
    * Массив пользователей
    */
   innerItems: UserModel[] = [] 
   user: any = null  // пользователь
   usersTookTheProgramIds: UserRequestModel[] = [] // массив с id пользователей c tookTheProgram = true
   usersIsAdminIds: UserRequestModel[] = [] // массив с id пользователей c isAdmin = true
   usersDelete: UserRequestModel[] = [] // массив с id пользователей, которые оформили программу

   /**
    * Пагинация
    */
   
   skip = 0;

   noteConfirm: boolean = false  // открытие модального c подтверждением




   @Watch('items') change() {
      this.setNewUserArray()
      console.log(this.items, "items");
   }

   created() {
      this.setNewUserArray()
      console.log(this.innerItems, 'innerItems');
   }

   setNewUserArray() {
      this.innerItems = this.items.map((item: any)  => {
         return item = new UserModel(
            item.id,
            '',
            item.name,
            item.email,
            item.phone ? item.phone : '',
            item.codeNumber ? item.codeNumber : '',
            item.isAdmin ? item.isAdmin : false,
            item.tookTheProgram,
            item.refferalLink ? window.location.origin + "/register-referal/" + item.refferalLink : '',
            false,
         )
      })
   }
  
   /**
    * Выбор пользователей для генерации рефералки (tookTheProgram = true)
    */
   changeCheckedProgram(item: UserModel) {
      this.usersTookTheProgramIds.push({userId: item.Id, tookTheProgram: item.TookTheProgram})
      // console.log(this.usersTookTheProgramIds, 'usersTookTheProgramIds');
   }

   /**
    * Выбор пользователей - админов (isAdmin = true)
    */
   changeCheckedAdmin(item: UserModel) {
      this.usersIsAdminIds.push({userId: item.Id, isAdmin: item.IsAdmin})
      // console.log(this.usersIsAdminIds, 'usersIsAdminIds');
   }

   /**
    * Выбор пользователей для удаления (isAdmin = true)
    */
   changeCheckedDelete(item: UserModel) {
      this.usersDelete.push({userId: item.Id})
      // console.log(this.usersDelete, 'usersDelete');
   }

   onPaginationChanged(value:{Page:number,CountOnPage:number}) {
      // value {Page: 2, CountOnPage: 10}
      this.page.Current=value.Page-1;
      this.skip = (value.Page-1) * value.CountOnPage;

      this.$emit('getUsers', this.skip, this.page.Size)
      // console.log(this.skip, this.page.Size, this.page.Count);
   }

   /**
    * Открытие окна с подтверждением
    */
   openPopupConfirm() {
      this.noteConfirm = true
      // this.user = this.items.find(el => el.id == item.id)
   }


   saveChanges() {
      this.setUserAdmin()
      this.setUserRefferalLink()
      this.deleteUsers()
   }
   

   /**
    * Сделать пользователей админами (API)
    */
   setUserAdmin() {
      var self = this

      var settings = {
         "url": "http://31.31.24.200:5051/Account/SetUserAdmin",
         "method": "POST",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "processData": false,
         "data": JSON.stringify(this.usersIsAdminIds)
      };

      $.ajax(settings).done(function (response) {
         self.noteConfirm = false
         window.location.reload()
      }); 
   }

   /**
    * Обозначаем пользователей, которые взяли программу (API)
    */
   setUserRefferalLink() {

      var self = this

      var settings = {
         "url": "http://31.31.24.200:5051/Account/SetUserRefferalLink",
         "method": "POST",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "processData": false,
         "data": JSON.stringify(this.usersTookTheProgramIds)
      };

      $.ajax(settings).done(function (response) {
         // console.log(response, 'response');
         self.noteConfirm = false
         window.location.reload()
      }); 
   }

   /**
    * Удаление пользователей
    */
   deleteUsers() {
      var self = this

      var settings = {
         "url": "http://31.31.24.200:5051/Account/DeleteUser",
         "method": "POST",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "processData": false,
         "data": JSON.stringify(this.usersDelete)
      };

      $.ajax(settings).done(function (response) {
         self.noteConfirm = false
         window.location.reload()
      }); 
   }

}
</script>

<style scoped>

.nav-wrap {
   margin-top: 40px;
   display: flex;
   align-items: center;
   justify-content: space-between;
}

@media all and (max-width: 700px) {
   .nav-wrap { flex-direction: column; align-items: flex-start; }
   .i-button-wrap { margin-bottom: 15px; }
}
</style>
