<template>
  <div class="monograph">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj monografie</h3>

    <form style ="margin-top:20px" v-on:submit="addMonograph">
      <div class="form-group">
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="autor">Autor</label>
            <input type="text" class="form-control"   placeholder="autor" v-model="monograph.autor">
          </div>
          <div class="form-group col-md-6">
            </br>
            <button type="button" class="btn btn-success mt-2">Dodaj siebie</button>
          </div>
        </div>
          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł" v-model="monograph.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control" v-model="monograph.description" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-12-19" v-model="monograph.date">
              </br>

          

            


              <label for="cityImput">Miasto</label>
              <input type="text" class="form-control"   placeholder="miasto" v-model="monograph.city">
                </br>

                <label for="publisherImput">Wydawca</label>
                <input type="text" class="form-control"   placeholder="wydawca" v-model="monograph.publisher" >
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


                    <button   class="btn btn-lg btn-primary btn-block">Dodaj monografię</button>


                  </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'Monograph',
  data(){
  return {
  monograph: {},
  alert: ""
  }
  },
  methods: {
  addMonograph(e) {
  if (
  !this.monograph.autor ||
  !this.monograph.title
  ) {
  this.alert = "Autor i tytuł to pola wymagane";
  } else {
  let newMonograph = {
  Autor: this.monograph.autor,
  Title: this.monograph.title,
  Description: this.monograph.description,
  Date: this.monograph.date,
  City: this.monograph.city,
  Publisher: this.monograph.publisher




  }
  this.$http.post('http://localhost:50906/api/accounts', newMonograph)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano część książki'}});
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
