
<script setup>
import {onMounted, ref} from "vue";

const word = ref('');
const info = ref('');
const showInfo = ref(false);
const showButton = ref(true);

async function fetchWord() {
  const response = await fetch('http://localhost:5200/api/ReviewWord');
  const data = await response.json();
  word.value = data.wordOfReview;
  info.value = data.infoOfReview;
  showInfo.value = false;
  showButton.value = true;
}

onMounted(fetchWord);
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
}
function Next() {
  toggleInfo();
  fetchWord();
}
</script>

<template>
  <div id="reviewer" class="card">
    <h1 class="card-title">{{word}}</h1>
    <div id="infoContainer" class="card">
      <transition name="fade">
      <pre v-if="showInfo" id="info">{{info}}</pre>
      </transition>
    </div>
    <div>
      <button
          id="define-btn"
          @click="chooseYes"
          v-if="showButton"
          type="button"
          class="btn btn-light">
        认识
      </button>


      <button
          id="define-btn"
          @click="toggleInfo"
          v-if="showButton"
          type="button"
          class="btn btn-light">
        不认识
      </button>


      <button id="next-btn"
              @click="Next"
              v-if="!showButton"
              type="button"
              class="btn btn-light">
        下一个
      </button>

    </div>
  </div>
</template>

<style scoped>
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
#YES-btn:hover,
#next-btn:hover {
  background-color: #4caf50; /* 绿色 */
  color: white;
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
  background-color: #eaeaea;
  background-image: url("https://img.picui.cn/free/2025/05/15/6825fa0213f67.jpg");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
  background-color: rgba(234, 234, 234, 0.7);
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
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.25s;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
#info{
  font-size: 18px;
}
</style>