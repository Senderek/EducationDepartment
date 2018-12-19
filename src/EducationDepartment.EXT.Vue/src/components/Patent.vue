<template>
  <div class="PatentT">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj patent</h3>

    <form style ="margin-top:20px" v-on:submit="addPatent">
      <div class="form-group">
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="autor">Wynalazca</label>
            <input type="text" class="form-control"   placeholder="wynalazca" v-model="patent.inventor">
          </div>
          <div class="form-group col-md-6">
            </br>
            <button type="button" class="btn btn-success mt-2">Dodaj siebie</button>
          </div>
        </div>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł"  v-model="patent.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control" v-model="patent.description" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-12-19" v-model="patent.date">
              </br>

              <label for="areaInput">Kraj/region</label>
              <input type="text" class="form-control"  placeholder="kraj/region" v-model="patent.region">
                </br>

                <label for="numberOfPatentInput">Numer patentu</label>
                <input type="text" class="form-control"   placeholder="numer patentu" v-model="patent.number">
                  </br>




                <label for="cityImput">Miasto</label>
                <input type="text" class="form-control"   placeholder="miasto" v-model="patent.city">
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


                      <button   class="btn btn-lg btn-primary btn-block">Dodaj patent</button>


                    </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'Patent',
  data(){
  return {
  patent: {},
  alert: ""
  }
  },
  methods: {
  addPatent(e) {
  if (
  !this.patent.inventor ||
  !this.patent.title
  ) {
  this.alert = "Wynalazca i tytuł to pola wymagane";
  } else {
  let newPatent = {
  Inventor: this.patent.inventor,
  Title: this.patent.title,
  Description: this.patent.description,
  Region: this.patent.region,
  Date: this.patent.date,
  City: this.patent.city,
  Number: this.patent.number




  }
  this.$http.post('http://localhost:50906/api/accounts', newPatent)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano patent'}});
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
