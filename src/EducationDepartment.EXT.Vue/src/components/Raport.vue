<template>
  <div class="raport">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj raport  </h3>

    <form style ="margin-top:20px" v-on:submit="addRaport">
      <div class="form-group">
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="autor">Autor</label>
            <input type="text" class="form-control"   placeholder="autor" v-model="raport.autor">
          </div>
          <div class="form-group col-md-6">
            </br>
            <button type="button" class="btn btn-success mt-2">Dodaj siebie</button>
          </div>
        </div>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł" v-model="raport.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control" v-model="raport.description" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-12-19" v-model="raport.date">
              </br>

              




                <label for="cityImput">Miasto</label>
                <input type="text" class="form-control"  placeholder="miasto" v-model="raport.city">
                  </br>

                  <label for="publisherImput">Wydawca</label>
                  <input type="text" class="form-control"   placeholder="wydawca" v-model="raport.publisher">
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


                      <button   class="btn btn-lg btn-primary btn-block">Dodaj raport</button>


                    </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'Raport',
  data(){
  return {
  raport: {},
  alert: ""
  }
  },
  methods: {
  addRaport(e) {
  if (
  !this.raport.autor ||
  !this.raport.title
  ) {
  this.alert = "Autor i tytuł to pola wymagane";
  } else {
  let newRaport = {
  Autor: this.raport.autor,
  Title: this.raport.title,
  Description: this.raport.description,
  Publisher: this.raport.publisher,
  Date: this.raport.date,
  City: this.raport.city





  }
  this.$http.post('http://localhost:50906/api/accounts', newRaport)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano raport'}});
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
