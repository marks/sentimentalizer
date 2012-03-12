require 'sinatra'
require 'json'
require './analyser'

Analyser.train_positive "../../data/positive"
Analyser.train_negative "../../data/negative"

get '/' do
  sentence = params[:sentence]
  content_type :json
  Analyser.analyse(sentence).to_json
end
