<template>
  <div class="conferenceArticle">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj materiał konferencyjny</h3>

    <form style ="margin-top:20px" v-on:submit="addConferenceArticle">
      <div class="form-group">
        <label for="autorImput">Autor</label>
        <input type="text" class="form-control"   placeholder="autor" v-model="conferenceArticle.autor">
          </br>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł" v-model="conferenceArticle.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control"  v-model="conferenceArticle.description" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-12-19"  v-model="conferenceArticle.date">
              </br>

              <label for="conferenceImput">Konferencja</label>
              <input type="text" class="form-control"   placeholder="konferencja" v-model="conferenceArticle.conference">
                </br>




                <label for="cityImput">Miasto</label>
                <input type="text" class="form-control"   placeholder="miasto" v-model="conferenceArticle.city">
                  </br>

                  






                    <label>Okładka</label>
                    <div class="input-group">
                      <span class="input-group-btn">
                        <span class="btn btn-default btn-file">
                          Wybierz… <input type="file" id="imgInp">
                </span>
                      </span>
                      <input type="text" class="form-control" readonly="">
        </div>
                    <img id='img-upload'/>




                    <label for="exampleInputFile">Załączniki</label>
                    <input type="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                      <small id="fileHelp" class="form-text text-muted">This is some placeholder block-level help text for the above input. It's a bit lighter and easily wraps to a new line.</small>


                      <button   class="btn btn-lg btn-primary btn-block">Dodaj materiał konferencyjny</button>


                    </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'ConferenceArticle',
  data(){
  return {
  conferenceArticle: {},
  alert: ""
  }
  },
  methods: {
  addConferenceArticle(e) {
  if (
  !this.conferenceArticle.autor ||
  !this.conferenceArticle.title
  ) {
  this.alert = "Autor i tytuł to pola wymagane";
  } else {
  let newConferenceArticle = {
  Autor: this.conferenceArticle.autor,
  Title: this.conferenceArticle.title,
  Description: this.conferenceArticle.description,
  Date: this.conferenceArticle.date,
  City: this.conferenceArticle.city,
  Conference: this.conferenceArticle.conference




  }
  this.$http.post('http://localhost:50906/api/accounts', newConferenceArticle)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano materiał konferencyjny'}});
  });

  e.preventDefault();
  }
  e.preventDefault();
  }
  },
  components: {
  Alert
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
