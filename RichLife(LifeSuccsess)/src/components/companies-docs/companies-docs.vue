<template>
   <div class="slider-wrap" v-if="docsArr" tabindex="0">
      <div class="slider-docs i-slider">
         <div v-for="item in docsArr" :key="item.Id" class="slide">
            <div class="doc" @click="showDoc(item.Id)">
               <img :src="item.Doc" alt="">
               <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-search"></use></svg>
            </div>
         </div>
      </div>

      <div class="i-slider-arrows docs-arrows"></div>
      
      <i-modal :show="showDocsModal" @close="hideDoc" >
         <div class="doc-wrap" v-if="currentDoc">
            <img :src="currentDoc.Doc" alt="">
         </div>
      </i-modal>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

// import $ from "jquery";
import CompaniesDocsModel from "./models/CompaniesDocsModel"

@Component
export default class CompaniesDocsComponent extends Vue {

   docsArr: CompaniesDocsModel[] = []  // массив с отзывами
   currentDoc: CompaniesDocsModel = null  // выбранный отзыв (кликнутый)

   showDocsModal: boolean = false  // флаг на модальное окно с видео

   created() {
      this.docsArr = [
         new CompaniesDocsModel(1, '/assets/img/docs/doc1.webp'),
         new CompaniesDocsModel(2, '/assets/img/docs/doc2.webp'),
         new CompaniesDocsModel(3, '/assets/img/docs/doc3.webp'),
         new CompaniesDocsModel(4, '/assets/img/docs/doc4.webp'),
         new CompaniesDocsModel(5, '/assets/img/docs/doc5.webp'),
         new CompaniesDocsModel(6, '/assets/img/docs/doc6.webp'),
         new CompaniesDocsModel(7, '/assets/img/docs/doc7.webp'),
         new CompaniesDocsModel(8, '/assets/img/docs/doc8.webp'),
         new CompaniesDocsModel(9, '/assets/img/docs/doc9.webp'),
         new CompaniesDocsModel(10, '/assets/img/docs/doc10.webp')
      ]
   }

   mounted() {
      this.initSlickSlider()
      window.addEventListener('resize', this.onGroupArrows)
   }


   /**
    * Открытие модального окна с отзывом
    */
   showDoc(id: number) {
      this.currentDoc = this.docsArr.find(el => el.Id == id)
      console.log(this.currentDoc, 'currentReview');
      
      if (this.currentDoc) 
         this.showDocsModal = true
   }

   /**
    * Закрытие модального окна с отзывом
    */
   hideDoc() {
      this.showDocsModal = false
   }

   /**
    * Инициализация slick-slider
    */
   initSlickSlider() {
      $('.slider-docs').slick({
         slidesToShow: 3,
         slidesToScroll: 2,
         infinite: true,
         dots: false,
         arrows: true,
         prevArrow: '<button class="i-slider-arrow docs-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
         nextArrow: '<button class="i-slider-arrow docs-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
         adaptiveHeight: true,
         responsive: [
            {
               breakpoint: 960,
               settings: {
                  slidesToShow: 2,
                  adaptiveHeight: true,
                  arrows: true,
                  prevArrow: '<button class="i-slider-arrow docs-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
                  nextArrow: '<button class="i-slider-arrow docs-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
               }
            },
            {
               breakpoint: 700,
               settings: {
                  centerMode: false,
                  centerPadding: '50px',
                  slidesToScroll: 1,
                  slidesToShow: 1,
                  arrows: true,
                  adaptiveHeight: true,
                  prevArrow: '<button class="i-slider-arrow docs-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
                  nextArrow: '<button class="i-slider-arrow docs-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
               }
            }
         ]
      })

      this.onGroupArrows()
   }

   onGroupArrows() {
      $('.docs-arrows').append($('.docs-arrow'))
      $('.docs-arrow').css({ display: 'flex' })
   }

}
</script>

<style scoped>


/* slider */
.slide {
   padding: 15px 5px;
}

.i-slider-arrows {
   display: flex;
   align-items: center;
   justify-content: center;
   width: 100%;
}



.reviews-row {
   margin: 0 -7.5px;
}

.reviews-col {
   padding: 0 7.5px;
   margin-bottom: 15px;
   display: flex;
}

.doc {
   display: flex;
   flex-direction: column;
   width: 100%;
   max-height: 286px;
   position: relative;
   /* box-shadow: 0 0 42px rgba(0, 0, 0, 0.1); */
   cursor: pointer;
   transition: all 0.3s ease-out;
}

.doc::after,
.doc::before {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   opacity: 0;
   visibility: hidden;
   transition: all 0.3s ease-out;
}

.doc::after {
   border: 10px solid #12be83;
   transform: scale(1.05);
}

.doc::before {
   background: rgba(0, 0, 0, 0.4);
   opacity: 1;
   visibility: visible;
}

.doc img {
   max-width: 100%;
   max-height: 286px;
   height: auto;
}

.doc:hover {
   transform: translateY(-7px);
}

.doc:hover::after {
   transform: scale(1);
   opacity: 1;
   visibility: visible;
}

.doc:hover::before {
   opacity: 0;
   visibility: hidden;
}




/* svg */
.doc svg {
   position: absolute;
   top: 50%;
   left: 50%;
   transform: translate(-50%, -50%);
   width: 40px;
   height: 40px;
   fill: rgba(240, 240, 245, 0.6);
   z-index: 2;
   transition: all 0.2s ease-out;
}

.doc:hover svg {
   fill: rgba(18, 190, 131, 0.6);
}



/* video */
.doc-wrap {
   width: 100%;
   height: auto;
   border-radius: 10px;
   overflow: hidden;
}

.doc-wrap img {
   max-width: 100%;
   height: auto;
}
</style>

<style>
.i-slider-arrow {
   margin: 0 10px;
   background: transparent;
   display: flex;
   align-items: center;
   opacity: 0;
   visibility: hidden;
   transition: all 0.3s ease-out;
}

.i-slider-arrow svg {
   width: 40px;
   height: 40px;
   fill: #12be83;
   transition: all 0.3s ease-out;
}

.i-slider-arrow.prev svg {
   transform: rotate(180deg);
}

.i-slider-arrow:hover svg,
.i-slider-arrow:focus svg {
   fill: #0da671;
}


.i-slider-arrow.prev {
   transform: translateX(-10px);
}

.i-slider-arrow.next {
   transform: translateX(10px);
}

.slider-wrap:hover .i-slider-arrow,
.slider-wrap:focus .i-slider-arrow {
   opacity: 1;
   visibility: visible;
   transform: translateX(0);
}


</style>