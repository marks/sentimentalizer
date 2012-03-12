require "../engine/corpus"
require "../engine/classifier"

class Analyser

  @@positive = Corpus.new
  @@negative = Corpus.new

  def Analyser.train_positive path
    @@positive.load_from_directory path
  end

  def Analyser.train_negative path
    @@negative.load_from_directory path
  end

  def Analyser.analyse sentence
    Classifier.new(@@positive, @@negative).classify(sentence)
  end
end
