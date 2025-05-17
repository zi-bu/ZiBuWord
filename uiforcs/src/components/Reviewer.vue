
<script setup>
import {onMounted, ref} from "vue";

const word = ref('');
const info = ref('');
const showInfo = ref(false);
const showButton = ref(true);
const listCount = ref(1);

async function fetchWord() {
  const response = await fetch('http://localhost:5200/api/ReviewWord');
  const data = await response.json();
  word.value = data.wordOfReview;
  info.value = data.infoOfReview;
  showInfo.value = false;
  showButton.value = true;
}

async function fetchWordListCount() {
  const response = await fetch('http://localhost:5200/api/ReviewWord/wordListCount');
  const data = await response.json();
  listCount.value = data.wordListCount;
}

onMounted(() => {
  fetchWord();
  fetchWordListCount();
});

function toggleInfo() {
  showInfo.value = !showInfo.value;
  showButton.value = !showButton.value;
}
//是的按钮触发事件
function chooseYes(){
  toggleInfo();
  fetch('http://localhost:5200/api/ReviewWord/EventYes', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({})
  })
      .then(res => res.json())
      .then(data => {
        // 处理返回数据
        console.log(data);
      });
  fetchWordListCount();
  showCondition();
}
function chooseNo(){
  toggleInfo();
  fetch('http://localhost:5200/api/ReviewWord/EventNo', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({})
  })
      .then(res => res.json())
      .then(data => {
        // 处理返回数据
        console.log(data);
      });
  fetchWordListCount();
  showCondition();
}
function Next() {
  toggleInfo();
  fetchWord();
  fetchWordListCount();
}
</script>

<template>
  <div class="background">
    <div id="reviewer" class="card">
      <transition name="fade">
        <div v-show="listCount !== 0" id="reviewerInside">
          <h1 class="card-title">{{word}}</h1>
          <div id="infoContainer" class="card">
            <transition name="fade">
              <pre v-if="showInfo" id="info">{{info}}</pre>
            </transition>
          </div>
          <div>
            <button
                v-if="showButton"
                id="define-btn"
                class="btn btn-light"
                type="button"
                @click="chooseYes">
              认识
            </button>
            <button
                v-if="showButton"
                id="define-btn"
                class="btn btn-light"
                type="button"
                @click="chooseNo">
              不认识
            </button>
            <button
                v-if="!showButton"
                id="next-btn"
                class="btn btn-light"
                type="button"
                @click="Next">
              下一个
            </button>
          </div>
        </div>
      </transition>
      <transition name="fade">
        <div v-show="listCount === 0" id="overcard" class="card">
          <p>本队列单词复习完毕</p>
        </div>
      </transition>
      <transition name="fade">
        <div>
          <button v-show="listCount === 0" id="define-btn" class="btn btn-light" @click="Next">开始新的背诵队列</button>
          <button v-show="listCount === 0" id="define-btn" class="btn btn-light" @click="">返回主页面</button>
        </div>
      </transition>
    </div>
  </div>
</template>

<style scoped>
.background{
  background-image: url('/img/background/7.jpg');
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
  height: 800px;
  width: 600px;
}

#define-btn{
  height:  60px;
  width: 225px;
  margin-bottom: 50px;
  margin-top: 20px;
  font-weight: bold;
}
#define-btn,
#next-btn {
  border: none;         /* 去除边框 */
  box-shadow: none;     /* 去除阴影 */
  outline: none;        /* 去除点击后的外边框 */
}

#YES-btn:hover,#next-btn:hover {
  background-color: #4caf50; /* 绿色 */
  color: white;
  /*noinspection CssInvalidPropertyValue*/
  transition: background-color 0.2;
}
#next-btn{
  height:  60px;
  width: 450px;
  margin-bottom: 50px;
  margin-top: 20px;
  font-weight: bold;
}
#reviewer {
  height: 800px;
  width: 600px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
#reviewerInside{
  height: 800px;
  width: 600px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#reviewer h1 {
  margin-top: 100px;
  color: white;
  font-weight: bold;
  font-size: 48px;
  text-shadow:
      -2px -2px 0 #000,
      2px -2px 0 #000,
      -2px  2px 0 #000,
      2px  2px 0 #000;
}
#infoContainer{
  background-color: rgba(255, 255, 255, 0.64);
  height: 450px;
  width: 450px;
  margin-top: 40px;
  margin-bottom:10px ;
}
#infoContainer pre{
  margin-left: 10px;
  margin-top: 5px;
}

#overcard{
  height: 60px;
  width: 450px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background-color: rgba(255, 255, 255, 0.64);
}
#overcard p{
  margin-left: 10px;
  margin-top: 15px;
  font-weight: bold;
}


#info{
  font-size: 18px;
}
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
.fade-enter-to, .fade-leave-from {
  opacity: 1;
}
</style>