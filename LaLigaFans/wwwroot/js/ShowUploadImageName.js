const actualBtn = document.getElementById('actual-btn');
const fileChosen = document.getElementById('file-chosen');

actualBtn.addEventListener('change', getFileName);

async function getFileName() {
    fileChosen.textContent = this.files[0].name;
}