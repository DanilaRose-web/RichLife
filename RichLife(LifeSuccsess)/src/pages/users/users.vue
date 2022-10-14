<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch"> 
      <template slot="header">
         <minimal-header-home @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Список пеользователей</span>
      </breadcrumbs>

      <section class="section-users">
         <i-container>
            <div class="i-title dancing">List of Users</div>
            <h1 class="i-title section-title user-title">Список пользователей</h1>
            <h5 class="i-subtitle reviews-subtitle">В таблице ниже отображены все пользователи, зарегистрированные на этом сайте. Для того, чтобы отметить пользователей, которые уже приобрели программу, назначить администраторм или удалить пользователя, нажмите на соответствующий чекбокс в последней ячейке строки</h5>
            
            <div class="table-wrap">
               <search-form @searchEmpty="searchEmpty" @search="onSearch"></search-form>
               <!-- <p class="i-text warning-text">*Для более точного поиска, заполняйте поле "Поиск", находясь на 1-ой странице таблицы</p> -->
               <table-users @getUsers="changePagination" :page="page" :items="listOfUsers" />
            </div>
         </i-container>
      </section>

      <!-- Форма регистрации -->
      <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <!-- Модалка проверки авторизации -->
      <i-modal :contentMaxWidth="'600px'" :show="noteGetInTouch" @close="noteGetInTouch = false">
         <notification-get-in-touch @click="onShowJoinModal"></notification-get-in-touch>
      </i-modal>

      <!-- Оставить заявку -->
      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>

      <!-- <template slot="footer">
         <layout-footer @showJoinModalFooter="onShowJoinModalFooter"></layout-footer>
      </template> -->
   </layout>
</template>  

<script lang="ts">
import Vue from "vue";
import { Component, Watch } from "vue-property-decorator"

import cookie from "js-cookie"
import UserModel from "src/models/UserModel";
import PageModel from "../../models/PageModel";

@Component
export default class PageUsersComponent extends Vue {


   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию

   /**
    * Список пользователей
    */
   listOfUsers: UserModel[] = []

   /**
    * Пагинация
    */
   page: PageModel = null

   skip: number = 0
   take: number = 10
   search: string = ''


   created() {
      this.requestListOfUsers()
      if (cookie.get('token') == undefined) 
         this.$router.push({ name: 'sign' })
   }

   /**
    * Emit, который передает значение флага для открытия формы join из layout (т.к. layout-footer инициализируется в layout, а не на этой странице)
    */
   onShowJoinModalFooter(showJoinModalFooter: boolean) {
      this.showJoinModal = showJoinModalFooter
   }

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.noteGetInTouch = false
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }

   /**
    * Окрытие окна с чатом при клике на "связаться с нами" из services-menu
    */
   onCallUs() {
      this.openChat = true
      this.innerShowMenu = false
   }

   onChangeShow(show: boolean) {
      this.innerShowMenu = show
   }

   /**
    * Передача флага open: false, из компонента modal-chat при закрытии чата
    */
   onCloseChat(open: boolean) {
      this.openChat = open
   }

   /**
    * Открытие модального окна с проверкой на авторизацию
    */
   openNoteModal() {
      this.noteGetInTouch = true
   }

   /**
    * Открытие модалки на проверку авторизации, при клике на "Оставить заявку"
    */
   onGetInTouch() {
      if (cookie.get('token') == '' || cookie.get('token') == undefined) {
         this.noteGetInTouch = true
      } else {
         this.getInTouch = true
      }
   }

   /**
    * Зпрашиваем список пользователей с сервера при изменении пагинации
    */
   changePagination(skip: number, take: number) {
      this.skip = skip
      this.take = take
      this.requestListOfUsers()
   }

   /**
    * Поиск
    */
   onSearch(search: string) {
      this.search = search
      if (this.search != '') {
         this.skip = 0,
         this.take = 10
      }
      this.requestListOfUsers()
   }

   /**
    * Получение списка пользователей при пустой строке поиска
    */
   searchEmpty(search: string) {
      this.search = search
      this.requestListOfUsers()
   }


   /**
    * Запрос на получение списка пользователей
    */
   requestListOfUsers() {
      var self = this

      var settings = {
         "url": "http://31.31.24.200:5051/Account/ListOfUsers?Skip=" + self.skip + "&Take=" + self.take + "&Search=" + self.search,
         "method": "GET",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "processData": false,
         "mimeType": "multipart/form-data",
      };

      $.ajax(settings).done(function (response) {
         var innerlistOfUsers = new Function( 'return (' + response + ')' )();
         
         self.page = new PageModel(
            innerlistOfUsers.data.count, 
            innerlistOfUsers.data.size, 
            innerlistOfUsers.data.current
         )

         self.listOfUsers = innerlistOfUsers.data.data
      }); 
   }
}
</script>

<style scoped> 

.section-users {
   margin: 30px 0 60px 0;
}

.warning-text {
   margin-bottom: 20px;
   font-size: 13px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
}

@media all and (max-width: 380px) {
   .user-title { font-size: 24px; }
}
</style>