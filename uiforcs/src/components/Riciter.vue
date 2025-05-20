<script setup>
import Background from './Background.vue';
import { onMounted, ref } from 'vue';

const accurateWord = ref('');
const selection = ref([]);
const selectionWord = ref([]);

async function fetchContent() {
    const response = await fetch('http://localhost:5200/api/RiciterWord/selection');
    const data = await response.json();
    accurateWord.value = data.accurateWord;
    for (var i = 0; i < 4; i++) {
        selection.value[i] = `${data.selection[i].pos[0]}.${data.selection[i].translations[0]}`;
        selectionWord.value[i] = data.selection[i].word;
    }
    console.log(data);
}
function choice(i){
    const requestBody = {
        result: accurateWord.value === selectionWord.value[i],
    };
    console.log(requestBody);
    fetch('http://localhost:5200/api/RiciterWord/Event', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(requestBody)
    })
    .then(res => res.json())
    .then(data => {
    console.log('服务器响应:', data);
    })
    .catch(error => {
    console.error('请求失败:', error);
    });
}

onMounted(() => {
  fetchContent(); 
})
</script>
<template>
    <div id="Box">
        <Background />
        <div id="Content">
            <h1 id="Word">{{accurateWord}}</h1>
        </div>
        <div id ="Selection" class="card">
            <button class="btn btn-light" @click="choice(0)">{{selection[0]}}</button>
        </div>
        <div id ="Selection" class="card">
            <button class="btn btn-light" @click="choice(1)">{{selection[1]}}</button>
        </div>
        <div id ="Selection" class="card">
            <button class="btn btn-light" @click="choice(2)">{{selection[2]}}</button>
        </div>
        <div id ="Selection" class="card">
            <button class="btn btn-light" @click="choice(3)">{{selection[3]}}</button>
        </div>
    </div>
</template>

<style scoped>
#Box {
  margin: 0 auto;
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  top: 0;
  width: 600px;
  height: 800px;
  margin: 0;
}
#Content  {
    position: relative;
    display: grid;
    width: 85%;
    height: 15%;
    margin: auto;
    top: 10%;
    border: 0;
    
}
#Content h1  {
    text-align: center;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: auto;
    color: white;
    font-weight: bold;
    font-style: inherit;
    font-size: 40px;
    text-shadow: 0 0 8px rgba(0, 0, 0, 1);
}

#Selection  {
    position: relative;
    display: inline-grid;
        width: 85%;
        height: 10%;
    margin: auto;
    top: 25%;
    left: 50%;
    transform: translate(-50%, -75%);
    background: rgba(255, 255, 255, 0);
    padding: 60px 0;
    border: 0;
}
#Selection button {
    position: absolute;
    width: 100%;
    height: 100%;
    margin: 0%;
    color: white;
    font-weight: bold;
    font-size: 20px;
    background: rgba(255, 255, 255, 0.5);
    text-shadow: 0 0 8px rgba(0, 0, 0, 1);
    text-align: left;
    border: 0;
}
#Selection button:hover {
    position: absolute;
    width: 100%;
    height: 100%;
    margin: 0%;
    color: white;
    font-weight: bold;
    font-size: 20px;
    background: rgba(83, 113, 232, 0.432);
    text-shadow: 0 0 8px rgb(18, 168, 255);
    text-align: left;
    border: 0;
}


</style>