require "#{File.dirname(__FILE__)}/corpus"
require "#{File.dirname(__FILE__)}/classifier"

class Analyser

  @@positive = Corpus.new
  @@negative = Corpus.new

  def Analyser.train_positive path
    puts "Training analyser with +ve sentiment"
    @@positive.load_from_directory path
    puts "+ve sentiment training complete"
  end

  def Analyser.train_negative path
    puts "Training analyser with -ve sentiment"
    @@negative.load_from_directory path
    puts "-ve sentiment training complete"
  end

  def Analyser.analyse sentence
    Classifier.new(@@positive, @@negative).classify(sentence)
  end
end
