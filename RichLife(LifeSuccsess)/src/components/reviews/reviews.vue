<template>
   <div class="slider-wrap" v-if="reviewArr" tabindex="0">
      <div class="slider-review i-slider">
         <div v-for="item in reviewArr" :key="item.Id" class="slide">
            <div class="review" @click="showReview(item.Id)">
               <img :src="item.Poster" :alt="item.ClientName">
               <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-play"></use></svg>
            </div>
         </div>
      </div>

      <div class="i-slider-arrows reviews-arrows"></div>
      
      <i-modal :show="showReviewModal" @close="hideReview" >
         <div class="review-video">
            <iframe height="400" v-if="currentReview" :src="currentReview.VideoUrl" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
         </div>
      </i-modal>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

import ReviewModel from "./models/ReviewModel"  // модель отзыва
// import $ from "jquery";

@Component
export default class ReviewsComponent extends Vue {

   reviewArr: ReviewModel[] = []  // массив с отзывами
   currentReview: ReviewModel = null  // выбранный отзыв (кликнутый)

   showReviewModal: boolean = false  // флаг на модальное окно с видео

   created() {
      this.reviewArr = [
         new ReviewModel(1, '/assets/img/reviews/review1.webp', 'https://www.youtube.com/embed/cvOdUvtJ5FA', 'Светлана Бондаренко'),
         new ReviewModel(2, '/assets/img/reviews/review2.webp', 'https://www.youtube.com/embed/IHxCQxDuraw', 'Анжела Бикир'),
         new ReviewModel(3, '/assets/img/reviews/review3.webp', 'https://www.youtube.com/embed/AxwdX382POU', 'Екатерина Суховольская'),
         new ReviewModel(4, '/assets/img/reviews/review4.webp', 'https://www.youtube.com/embed/Eix4jhlZDc8', 'Ирина Кирица'),
         new ReviewModel(5, '/assets/img/reviews/review5.webp', 'https://www.youtube.com/embed/0cSbCHs7rlA', 'Владимир Чимпоеш'),
         new ReviewModel(6, '/assets/img/reviews/review6.webp', 'https://www.youtube.com/embed/qEYHP3RD1iw', 'Дарья Донцова')
      ]

      
   }

   mounted() {
      this.initSlickSlider()
      window.addEventListener('resize', this.onGroupArrows)
   }


   /**
    * Открытие модального окна с отзывом
    */
   showReview(id: number) {
      this.currentReview = this.reviewArr.find(el => el.Id == id)
      console.log(this.currentReview, 'currentReview');
      
      if (this.currentReview) 
         this.showReviewModal = true
   }

   /**
    * Закрытие модального окна с отзывом
    */
   hideReview() {
      this.showReviewModal = false
   }

   /**
    * Инициализация slick-slider
    */
   initSlickSlider() {
      $('.slider-review').slick({
         slidesToShow: 3,
         slidesToScroll: 2,
         infinite: true,
         dots: false,
         arrows: true,
         prevArrow: '<button class="i-slider-arrow review-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
         nextArrow: '<button class="i-slider-arrow review-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
         responsive: [
            {
               breakpoint: 960,
               settings: {
                  slidesToShow: 2,
                  arrows: true,
                  prevArrow: '<button class="i-slider-arrow review-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
                  nextArrow: '<button class="i-slider-arrow review-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
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
                  prevArrow: '<button class="i-slider-arrow review-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
                  nextArrow: '<button class="i-slider-arrow review-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
               }
            }
         ]
      })

      this.onGroupArrows()
   }

   onGroupArrows() {
      $('.reviews-arrows').append($('.review-arrow'))
      $('.review-arrow').css({ display: 'flex' })
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

.review {
   display: flex;
   flex-direction: column;
   width: 100%;
   position: relative;
   /* box-shadow: 0 0 42px rgba(0, 0, 0, 0.1); */
   cursor: pointer;
   transition: all 0.3s ease-out;
}

.review::after,
.review::before {
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

.review::after {
   border: 10px solid #12be83;
   transform: scale(1.05);
}

.review::before {
   background: rgba(0, 0, 0, 0.4);
   opacity: 1;
   visibility: visible;
}

.review img {
   max-width: 100%;
   height: auto;
}

.review:hover {
   transform: translateY(-7px);
}

.review:hover::after {
   transform: scale(1);
   opacity: 1;
   visibility: visible;
}

.review:hover::before {
   opacity: 0;
   visibility: hidden;
}




/* svg */
.review svg {
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

.review:hover svg {
   fill: rgba(18, 190, 131, 0.6);
}



/* video */
.review-video {
   width: 100%;
   height: 100%;
   border-radius: 10px;
   overflow: hidden;
}

.review-video iframe {
   width: 100%;
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