<template>
  <div class="article">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj artykuł</h3>

    <form style ="margin-top:20px" v-on:submit="addArticle">
      <div class="form-group">
       
          
          
            <div class="form-row">
          <div class="form-group col-md-6">
          <label for="autor">Autor</label>
          <input type="text" class="form-control"   placeholder="autor" v-model="article.autor">
          </div>
         <div class="form-group col-md-6">
          </br>
          <button type="button" class="btn btn-success mt-2">Dodaj siebie</button>
          </div>
         </div>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł" v-model="article.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control"  v-model="article.description" rows="5"></textarea>
            </br>

            <label for="magazinNameImput">Magazyn/czasopismo</label>
            <input type="text" class="form-control" v-model="article.magazinName" placeholder="nazwa czasopisma/magazynu">
              </br>

            <label for="example-date-input"  >Data</label>
            </br>

              <input class="form-control" type="date" value="2018-12-19" v-model="article.date">
                </br>

            <label for="pagesImput">Strony</label>
            <input type="text" class="form-control" placeholder="strony" v-model="article.pages">
              </br>

             


                <label for="cityImput">Miasto</label>
                <input type="text" class="form-control" placeholder="miasto" v-model="article.city">
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


                      <button   class="btn btn-lg btn-primary btn-block">Dodaj artykuł</button>


                    </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'Article',
  data(){
  return {
  article: {},
  alert: ""
  }
  },
  methods: {
  addArticle(e) {
  if (
  !this.article.autor ||
  !this.article.title
  ) {
  this.alert = "Autor i tytuł to pola wymagane";
  } else {
  let newArticle = {
  ContentFields: [{ 
  }]
  }
  this.$http.post('http://localhost:50906/api/Article/', newArticle)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano artykuł'}});
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
